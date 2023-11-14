import psycopg2
import base64
from fastapi import FastAPI, Response, status
from fastapi.middleware.cors import CORSMiddleware
from db_models import *
from queries import router as queries_router, get_cursor

app = FastAPI()
app.include_router(queries_router)

# `uvicorn main:app --reload`

origins = ["http://localhost:3000"]

app.add_middleware(
    CORSMiddleware,
    allow_origins=origins,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)


@app.get('/{table_name}/getCols', status_code=200)
def get_table_cols(table_name: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"SELECT column_name FROM information_schema.columns WHERE table_name = '{table_name}'")
            column_names = [col[0].replace("_id", "")
                            for col in cursor.fetchall()]
            response.status_code = status.HTTP_200_OK
        return {"column_names": column_names}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.get('/ref/{reference_name}/getAll', status_code=200)
def get_all_rows(reference_name: str, page: int, limit: int, response: Response):
    offset = (page - 1) * limit
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"SELECT * FROM {reference_name} ORDER BY id LIMIT {limit} OFFSET {offset}")
            rows = cursor.fetchall()

            cursor.execute(
                f"SELECT column_name FROM information_schema.columns WHERE table_name = '{reference_name}'")
            cols = cursor.fetchall()

            result = []
            for row in rows:
                row_dict = {}
                for i, col in enumerate(cols):
                    row_dict[col[0]] = row[i]
                result.append(row_dict)
            cursor.execute(f"SELECT COUNT(*) FROM {reference_name}")
            total_rows = cursor.fetchone()[0]
            response.status_code = status.HTTP_200_OK
            return {"rows": result, "total": total_rows}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"An unhandled error occurred: {e}"}

@app.delete('/{table_name}/delete/{table_id}', status_code=200)
def delete_row(table_name: str, table_id: int, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"DELETE FROM {table_name} WHERE id = {table_id}")
            response.status_code = status.HTTP_200_OK
            return {"success": f"Удаление успешно."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        print(e)
        return {"error": f"Возникла необработанная ошибка: {e}"}


# Cities


@app.post('/cities/add', status_code=200)
def add_city(data: Cities, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"INSERT INTO cities VALUES (DEFAULT, '{data.city}')")
            response.status_code = status.HTTP_201_CREATED
            return {"success": f"Город c названием '{data.city}' добавлен."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.get('/cities/getByValue', status_code=200)
def get_city_by_value(city: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT * FROM cities 
                            WHERE city ILIKE '%{city}%'
                            ORDER BY id 
                            LIMIT 50 
                            """)
            city = {
                "id": "",
                "city": "",
            }
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                city["id"] = row[0]
                city["city"] = row[1]
                result.append(dict(city))
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/cities/update/{city_id}', status_code=200)
def update_city(city_id: int, data: Cities, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"UPDATE cities SET city = '{data.city}' WHERE id = {city_id}")
            response.status_code = status.HTTP_200_OK
            return {"success": "Город успешно изменен."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


# Properties


@app.get('/properties/getByValue', status_code=200)
def get_position_by_value(position: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT * FROM properties 
                            WHERE position ILIKE '%{position}%'
                            ORDER BY id 
                            LIMIT 50 
                            """)
            position = {
                "id": "",
                "position": "",
            }
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                position["id"] = row[0]
                position["position"] = row[1]
                result.append(dict(position))
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/properties/add', status_code=200)
def add_position(data: Properties, response: Response):
    try:
        with get_cursor() as cursor:
            print(data)
            cursor.execute(
                f"INSERT INTO properties VALUES (DEFAULT, '{data.position}')")
            response.status_code = status.HTTP_201_CREATED
            return {"success": "Тип собственности успешно добавлен."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/properties/update/{position_id}', status_code=200)
def update_position(position_id: int, data: Properties, response: Response):
    cursor = get_cursor()
    try:
        with get_cursor() as cursor:
            print(position_id)
            cursor.execute(
                f"UPDATE properties SET position = '{data.position}' WHERE id = {position_id}")
            response.status_code = status.HTTP_200_OK
            return {"success": "Тип собственности успешно изменен."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


# Positions


@app.get('/positions/getByValue', status_code=200)
def get_position_by_value(position: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT * FROM positions 
                            WHERE position ILIKE '%{position}%'
                            ORDER BY id 
                            LIMIT 50 
                            """)
            position = {
                "id": "",
                "position": "",
            }
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                position["id"] = row[0]
                position["position"] = row[1]
                result.append(dict(position))
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/positions/add', status_code=200)
def add_position(data: Positions, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"INSERT INTO positions VALUES (DEFAULT, '{data.position}')")
            response.status_code = status.HTTP_201_CREATED
            return {"success": "Тип собственности успешно добавлен."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/positions/update/{position_id}', status_code=200)
def update_position(position_id: int, data: Positions, response: Response):
    try:
        with get_cursor() as cursor:
            print(position_id)
            cursor.execute(
                f"UPDATE positions SET position = '{data.position}' WHERE id = {position_id}")
            response.status_code = status.HTTP_200_OK
            return {"success": "Должность успешно изменена."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


# Care_products


@app.get('/care_products/getByValue', status_code=200)
def get_care_product_by_value(care_product: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT * FROM care_products 
                            WHERE care_product ILIKE '%{care_product}%'
                            ORDER BY id 
                            LIMIT 50 
                            """)
            care_product = {
                "id": "",
                "care_product": "",
                "unit": "",
            }
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                care_product["id"] = row[0]
                care_product["care_product"] = row[1]
                care_product["unit"] = row[2]
                result.append(dict(care_product))
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/care_products/add', status_code=200)
def add_care_product(data: CareProduct, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"INSERT INTO care_products VALUES (DEFAULT, '{data.care_product}', '{data.unit}')")
            response.status_code = status.HTTP_201_CREATED
            return {"success": f"Средство ухода c названием '{data.care_product}' добавлено."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/care_products/update/{care_product_id}', status_code=200)
def update_care_product(care_product_id: int, data: CareProduct, response: Response):
    try:
        with get_cursor() as cursor:
            print(care_product_id)
            cursor.execute(
                f"UPDATE care_products SET care_product = '{data.care_product}', unit ='{data.unit}' WHERE id = {care_product_id}")
            response.status_code = status.HTTP_200_OK
            return {"success": "Средство ухода успешно изменено."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


# Families


@app.get('/families/getByValue', status_code=200)
def get_family_by_value(family: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT * FROM families 
                            WHERE family ILIKE '%{family}%'
                            ORDER BY id 
                            LIMIT 50 
                            """)
            family = {
                "id": "",
                "family": "",
            }
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                family["id"] = row[0]
                family["family"] = row[1]
                result.append(dict(family))
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/families/add', status_code=200)
def add_family(data: Families, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"INSERT INTO families VALUES (DEFAULT, '{data.family}')")
            response.status_code = status.HTTP_201_CREATED
            return {"success": f"Семейcтво c названием '{data}' добавлено."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/families/update/{family_id}', status_code=200)
def update_family(family_id: int, data: Families, response: Response):
    cursor = get_cursor()
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"UPDATE families SET family = '{data.family}' WHERE id = {family_id}")
            response.status_code = status.HTTP_200_OK
            return {"success": "Семейcтво успешно изменено."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


# Generas


@app.get('/table/generas/getAll', status_code=200)
def get_generas(page: int, limit: int, response: Response):
    offset = (page - 1) * limit
    try:
        with get_cursor() as cursor:
            cursor.execute(f'''
                            SELECT g.id, g.genera, f.family 
                            FROM generas g
                            JOIN families f ON g.family_id = f.id
                            ORDER BY id 
                            LIMIT {limit} OFFSET {offset}
                            ''')
            genera = {
                "id": "",
                "genera": "",
                "family": "",
            }
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                genera["id"] = row[0]
                genera["genera"] = row[2]
                genera["family"] = row[1]
                result.append(dict(genera))
            cursor.execute("SELECT COUNT(*) FROM generas")
            total_rows = cursor.fetchone()[0]
            response.status_code = status.HTTP_200_OK
            return {"rows": result, "total": total_rows}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.get('/generas/getByValue', status_code=200)
def get_genera_by_value(genera: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT g.id, g.genera , f.family 
                            FROM generas g 
                            JOIN families f ON g.family_id = f.id 
                            WHERE genera ILIKE '%{genera}%' 
                            ORDER BY id 
                            LIMIT 50 
                            """)
            genera = {
                "id": "",
                "genera": "",
                "family": "",
            }
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                genera["id"] = row[0]
                genera["genera"] = row[1]
                genera["family"] = row[2]
                result.append(dict(genera))
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.get('/generas/via_family/{family_id}', status_code=200)
def get_generas_by_family(family_id: int, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"SELECT id, genera FROM generas WHERE family_id = {family_id} ORDER BY id")
            rows_list = cursor.fetchall()

            genera = {
                "id": "",
                "genera": "",
            }
            result = []
            for row in rows_list:
                genera["id"] = row[0]
                genera["genera"] = row[1]
                result.append(dict(genera))

            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/generas/add', status_code=200)
def add_generas(data: Genera, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"INSERT INTO generas VALUES (default, {data.family_id}, '{data.genera}')")
        response.status_code = status.HTTP_201_CREATED
        return {"success": f"Вид c названием '{data.genera}' добавлен."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/generas/update/{genera_id}', status_code=200)
def update_genera(genera_id: int, data: Genera, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"UPDATE generas SET genera = '{data.genera}', family_id = {data.family_id} WHERE id = {genera_id}")
            response.status_code = status.HTTP_200_OK
            return {"success": "Средство ухода успешно изменено."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


# Plants


@app.get('/table/plants/getAll', status_code=200)
def get_plants(page: int, limit: int, response: Response):
    offset = (page - 1) * limit
    try:
        with get_cursor() as cursor:
            cursor.execute(f'''
                            SELECT p.id, p.photo, p.price, p.planting, p.death, c.full_name, p.plot, p.conditions 
                            FROM plants p 
                            JOIN catalogue c ON p.catalogue_id = c.id 
                            ORDER BY p.id 
                            LIMIT {limit} OFFSET {offset}
                            ''')
            plant = {
                "id": "",
                "photo": "",
                "price": "",
                "planting": "",
                "death": "",
                "catalogue": "",
                "plot": "",
                "conditions": "",
            }
            result = []
            rows_list = cursor.fetchall()
            temp = bytearray()
            # print(psycopg2.Binary(rows_list[0][1]))
            for row in rows_list:
                plant["id"] = row[0]
                plant["photo"] = base64.b64encode(row[1])
                plant["price"] = row[2]
                plant["planting"] = row[3]
                plant["death"] = row[4]
                plant["catalogue"] = row[5]
                plant["plot"] = row[6]
                plant["conditions"] = row[7]
                result.append(dict(plant))
            cursor.execute("SELECT COUNT(*) FROM plants")
            total_rows = cursor.fetchone()[0]
            response.status_code = status.HTTP_200_OK
            return {"rows": result, "total": total_rows}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.get('/plants/getByValue', status_code=200)
def get_plant_by_value(plant: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT p.id, p.photo, p.price, p.planting, p.death, c.full_name, p.plot, p.conditions 
                            FROM plants p 
                            JOIN catalogue c ON p.catalogue_id = c.id 
                            WHERE full_name ILIKE '%{plant}%' 
                            ORDER BY id 
                            LIMIT 50 
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "id": row[0],
                    "photo": base64.b64encode(row[1]),
                    "price": row[2],
                    "planting": row[3],
                    "death": row[4],
                    "catalogue": row[5],
                    "plot": row[6],
                    "conditions": row[7],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        print(e)
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.get('/plants/get/{plant_id}', status_code=200)
def get_plant(plant_id: int, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f'''
                            SELECT p.id, p.price, p.planting, p.death, p.plot, p.conditions, c.full_name 
                            FROM plants p 
                            JOIN catalogue c ON p.catalogue_id = c.id 
                            WHERE p.id = {plant_id}
                            ORDER BY p.id
                            ''')
            plant = cursor.fetchall()
            if plant == []:
                response.status_code = status.HTTP_404_NOT_FOUND
                return {"error": "Вид не найден."}
            response.status_code = status.HTTP_200_OK
            return plant
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/plants/add', status_code=200)
def add_plants(data: Plants, response: Response):
    print(data)
    if data.death == None:
        death = "NULL"
    else:
        death = f"'{data.death}'"

    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"INSERT INTO plants VALUES (default, '{data.photo}', {data.price}, '{data.planting}', {death}, {data.catalogue_id}, {data.plot}, '{data.conditions}')")
            response.status_code = status.HTTP_201_CREATED
            return {"success": "Растение добавлено."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/plants/update/{plant_id}', status_code=200)
def update_plant(plant_id: int, data: Plants, response: Response):
    print(data)
    if data.death == None:
        death = "NULL"
    else:
        death = f"'{data.death}'"
    try:
        with get_cursor() as cursor:
            cursor.execute(f'''
                            UPDATE plants SET photo = '{data.photo}', price ={data.price}, planting ='{data.planting}', death ={death}, catalogue_id ={data.catalogue_id}, plot ={data.plot}, conditions ='{data.conditions}' 
                            WHERE id = {plant_id}
                            ''')
            response.status_code = status.HTTP_200_OK
            return {"success": "Растение успешно изменено."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


# Catalogue


@app.get('/table/catalogue/getAll', status_code=200)
def get_catalogue(page: int, limit: int, response: Response):
    offset = (page - 1) * limit
    try:
        with get_cursor() as cursor:
            cursor.execute(f'''
                            SELECT c.id, c.full_name, c.life_span, g.genera, c.annual 
                            FROM catalogue c 
                            JOIN generas g ON c.genera_id = g.id 
                            ORDER BY c.id 
                            LIMIT {limit} OFFSET {offset}
                            ''')
            catalogue = {
                "id": "",
                "full_name": "",
                "life_span": "",
                "genera": "",
                "annual": "",
            }
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                catalogue["id"] = row[0]
                catalogue["full_name"] = row[1]
                catalogue["life_span"] = row[2]
                catalogue["genera"] = row[3]
                catalogue["annual"] = row[4]
                result.append(dict(catalogue))
            cursor.execute("SELECT COUNT(*) FROM catalogue")
            total_rows = cursor.fetchone()[0]
            response.status_code = status.HTTP_200_OK
            return {"rows": result, "total": total_rows}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.get('/catalogue/getByValue', status_code=200)
def get_catalogue_by_value(catalogue: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT c.id, c.full_name, c.life_span, g.genera, c.annual 
                            FROM catalogue c 
                            JOIN generas g ON c.genera_id = g.id 
                            WHERE full_name ILIKE '%{catalogue}%' 
                            ORDER BY id 
                            LIMIT 50 
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "id": row[0],
                    "full_name": row[1],
                    "life_span": row[2],
                    "genera": row[3],
                    "annual": row[4],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        print(e)
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.get('/catalogue/via_genera/{genera_id}', status_code=200)
def get_catalogue_by_genera(genera_id: int, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"SELECT id, full_name FROM catalogue WHERE genera_id = {genera_id} ORDER BY id")
            rows_list = cursor.fetchall()

            catalogue = {
                "id": "",
                "full_name": "",
            }
            result = []
            for row in rows_list:
                catalogue["id"] = row[0]
                catalogue["full_name"] = row[1]
                result.append(dict(catalogue))

            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/catalogue/add', status_code=200)
def add_catalogue(data: Catalogue, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(
                f"INSERT INTO catalogue VALUES (default, '{data.full_name}', {data.life_span}, {data.genera_id}, {data.annual})")
            response.status_code = status.HTTP_201_CREATED
            return {"success": "Каталог добавлен."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/catalogue/update/{catalogue_id}', status_code=200)
def update_catalogue(catalogue_id: int, data: Catalogue, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f'''
                           UPDATE catalogue SET full_name = '{data.full_name}', life_span = {data.life_span}, genera_id = {data.genera_id}, annual = {data.annual} 
                           WHERE id = {catalogue_id}
                           ''')
            response.status_code = status.HTTP_200_OK
            return {"success": "Каталог успешно изменен."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


# Employees


@app.get('/table/employees/getAll', status_code=200)
def get_employees(page: int, limit: int, response: Response):
    offset = (page - 1) * limit
    try:
        with get_cursor() as cursor:
            cursor.execute(f'''
                            SELECT e.id, e.surname, e.name, e.patronymic, e.birth, p.position, e.experience, e.salary 
                            FROM employees e 
                            JOIN positions p ON e.position_id = p.id 
                            ORDER BY e.id 
                            LIMIT {limit} OFFSET {offset}
                            ''')
            employee = {
                "id": "",
                "surname": "",
                "name": "",
                "patronymic": "",
                "birth": "",
                "position": "",
                "experience": "",
                "salary": "",
            }
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                employee["id"] = row[0]
                employee["surname"] = row[1]
                employee["name"] = row[2]
                employee["patronymic"] = row[3]
                employee["birth"] = row[4]
                employee["position"] = row[5]
                employee["experience"] = row[6]
                employee["salary"] = row[7]
                result.append(dict(employee))
            cursor.execute("SELECT COUNT(*) FROM employees")
            total_rows = cursor.fetchone()[0]
            response.status_code = status.HTTP_200_OK
            return {"rows": result, "total": total_rows}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.get('/employees/getByValue', status_code=200)
def get_employee_by_value(employee: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT e.id, e.surname, e.name, e.patronymic, e.birth, p.position, e.experience, e.salary 
                            FROM employees e 
                            JOIN positions p ON e.position_id = p.id
                            WHERE surname ILIKE '%{employee}%' 
                            ORDER BY id 
                            LIMIT 50 
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "id": row[0],
                    "surname": row[1],
                    "name": row[2],
                    "patronymic": row[3],
                    "birth": row[4],
                    "position": row[5],
                    "experience": row[6],
                    "salary": row[7],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        print(e)
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/employees/add', status_code=200)
def add_employee(data: Employees, response: Response):
    print(data)
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                           INSERT INTO employees VALUES (default, 
                           '{data.surname}', 
                           '{data.name}', 
                           '{data.patronymic}', 
                           '{data.birth}', 
                           {data.position_id}, 
                           {data.experience}, 
                           {data.salary})
                           """)
            response.status_code = status.HTTP_201_CREATED
            return {"success": "Сотрудник добавлен."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/employees/update/{employee_id}', status_code=200)
def update_employee(employee_id: int, data: Employees, response: Response):
    print(data)
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            UPDATE employees SET 
                                surname = '{data.surname}', 
                                name = '{data.name}', 
                                patronymic = '{data.patronymic}', 
                                birth = '{data.birth}', 
                                position_id = {data.position_id}, 
                                experience = {data.experience}, 
                                salary = {data.salary} 
                            WHERE id = {employee_id}
                            """)
            response.status_code = status.HTTP_200_OK
            return {"success": "Сотрудник успешно изменен."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


# Service


@app.get('/table/service/getAll', status_code=200)
def get_service(page: int, limit: int, response: Response):
    offset = (page - 1) * limit
    try:
        with get_cursor() as cursor:
            cursor.execute(f'''
                            SELECT s.id, ct.full_name,  c.care_product, s.amount, s.fertilized, CONCAT(e.surname, ' ', LEFT(e.name, 1), '. ', LEFT(e.patronymic, 1), '.') AS employee
                            FROM service s 
                            JOIN plants p ON s.plant_id = p.id 
                            JOIN catalogue ct ON p.catalogue_id = ct.id
                            JOIN care_products c ON s.care_product_id = c.id 
                            JOIN employees e ON s.employee_id = e.id 
                            ORDER BY s.id 
                            LIMIT {limit} OFFSET {offset}
                            ''')
            service = {
                "id": "",
                "plant": "",
                "care_product": "",
                "amount": "",
                "fertilized": "",
                "employee": ""
            }
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                service["id"] = row[0]
                service["plant"] = row[1]
                service["care_product"] = row[2]
                service["amount"] = row[3]
                service["fertilized"] = row[4]
                service["employee"] = row[5]
                result.append(dict(service))

            cursor.execute("SELECT COUNT(*) FROM service")
            total_rows = cursor.fetchone()[0]
            response.status_code = status.HTTP_200_OK
            return {"rows": result, "total": total_rows}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.get('/service/getByValue', status_code=200)
def get_service_by_value(service: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT s.id, ct.full_name,  c.care_product, s.amount, s.fertilized, CONCAT(e.surname, ' ', LEFT(e.name, 1), '. ', LEFT(e.patronymic, 1), '.') AS employee
                            FROM service s 
                            JOIN plants p ON s.plant_id = p.id 
                            JOIN catalogue ct ON p.catalogue_id = ct.id
                            JOIN care_products c ON s.care_product_id = c.id 
                            JOIN employees e ON s.employee_id = e.id 
                            WHERE full_name ILIKE '%{service}%' 
                            ORDER BY s.id 
                            LIMIT 50 
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "id": row[0],
                    "plant": row[1],
                    "care_product": row[2],
                    "amount": row[3],
                    "fertilized": row[4],
                    "employee": row[5]
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        print(e)
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/service/add', status_code=200)
def add_service(data: Service, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f'''
                           INSERT INTO service VALUES (default, {data.plant_id}, {data.care_product_id}, {data.amount}, '{data.fertilized}', {data.employee_id})
                           ''')
            response.status_code = status.HTTP_201_CREATED
            return {"success": "Обслуживание добавлено."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/service/update/{service_id}', status_code=200)
def update_service(service_id: int, data: Service, response: Response):
    print(data)
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            UPDATE service SET 
                            plant_id = {data.plant_id}, 
                            care_product_id = {data.care_product_id}, 
                            amount = {data.amount}, 
                            fertilized = '{data.fertilized}', 
                            employee_id = {data.employee_id} 
                            WHERE id = {service_id} 
                            """)
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        print()
        print(e)
        return {"error": f"Возникла необработанная ошибка: {e}"}


# Gardens


@app.get('/table/gardens/getAll', status_code=200)
def get_gardens(page: int, limit: int, response: Response):
    offset = (page - 1) * limit
    try:
        with get_cursor() as cursor:
            cursor.execute(f'''
                            SELECT g.id, g.garden, g.opening, g.phone, g.financing, c.city, p.property, e.surname, e.name 
                            FROM gardens g 
                            JOIN cities c ON g.city_id = c.id 
                            JOIN properties p ON g.property_id = p.id 
                            JOIN employees e ON g.employee_id = e.id 
                            ORDER BY id 
                            LIMIT {limit} OFFSET {offset}
                            ''')
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "id": row[0],
                    "garden": row[1],
                    "opening": row[2],
                    "phone": row[3],
                    "financing": row[4],
                    "city": row[5],
                    "property": row[6],
                    "employee": row[7] + " " + row[8]
                })
            cursor.execute("SELECT COUNT(*) FROM gardens")
            total_rows = cursor.fetchone()[0]
            response.status_code = status.HTTP_200_OK
            return {"rows": result, "total": total_rows}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        print(e)
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.get('/gardens/getByValue', status_code=200)
def get_garden_by_value(garden: str, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT g.id, g.garden, g.opening, g.phone, g.financing, c.city, p.property, e.surname, e.name 
                            FROM gardens g 
                            JOIN cities c ON g.city_id = c.id 
                            JOIN properties p ON g.property_id = p.id 
                            JOIN employees e ON g.employee_id = e.id 
                            WHERE garden ILIKE '%{garden}%' 
                            ORDER BY id 
                            LIMIT 50 
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "id": row[0],
                    "garden": row[1],
                    "opening": row[2],
                    "phone": row[3],
                    "financing": row[4],
                    "city": row[5],
                    "property": row[6],
                    "employee": row[7] + " " + row[8]
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        print(e)
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/gardens/add', status_code=200)
def add_garden(data: Gardens, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                           INSERT INTO gardens VALUES (default, 
                           '{data.garden}', 
                           {data.opening}, 
                           {data.phone}, 
                           {data.financing}, 
                           {data.city_id}, 
                           {data.position_id}, 
                           {data.employee_id})
                           """)
            response.status_code = status.HTTP_201_CREATED
            return {"success": "Сад добавлен."}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@app.post('/gardens/update/{garden_id}', status_code=200)
def update_garden(garden_id: int, data: Gardens, response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            UPDATE gardens SET 
                            garden = '{data.garden}', 
                            opening = {data.opening}, 
                            phone = {data.phone}, 
                            financing = {data.financing}, 
                            city_id = {data.city_id}, 
                            property_id = {data.property_id}, 
                            employee_id = {data.employee_id} 
                            WHERE id = {garden_id} 
                            """)
            response.status_code = status.HTTP_200_OK
            return {"success": "Сад успешно изменен."}
    except Exception as e:
        print(e)
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}
