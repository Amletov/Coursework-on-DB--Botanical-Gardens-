import psycopg2
from fastapi import FastAPI, Response, status
from fastapi import APIRouter
from db_models import *

router = APIRouter()


def get_cursor():
    conn = psycopg2.connect(
        dbname='Kurs',
        user='postgres',
        password='0988',
        host='localhost',
        port='5434'
    )

    cursor = conn.cursor()
    conn.autocommit = True

    return cursor


@router.get("/queries/1", status_code=200)
def query_1(response: Response):
    try:
        with get_cursor() as cursor:
            # Все сады с типом собственности "Смешанная собственность"
            cursor.execute(f"""
                            SELECT g.id, g.garden, p.property
                            FROM gardens g
                            INNER JOIN properties p ON g.property_id = p.id
                            WHERE g.property_id = 3
                            ORDER BY g.id
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "Сад": row[1],
                    "Тип собственности": row[2],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@router.get("/queries/2", status_code=200)
def query_2(response: Response):
    try:
        with get_cursor() as cursor:
            # Все сады в городе "Санкт-Петербург"
            cursor.execute(f"""
                            SELECT g.id, g.garden, c.city
                            FROM gardens g
                            INNER JOIN cities c ON g.city_id = c.id
                            WHERE g.city_id = 2
                            ORDER BY g.id
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "Сад": row[1],
                    "Город": row[2],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@router.get("/queries/3", status_code=200)
def query_3(response: Response):
    try:
        with get_cursor() as cursor:
            # Список ухода за последниюю неделю
            cursor.execute(f"""
                            SELECT s.id, ct.full_name, s.fertilized, CONCAT(e.surname, ' ', LEFT(e.name, 1), '. ', LEFT(e.patronymic, 1), '.') AS employee
                            FROM service s 
                            JOIN plants p ON s.plant_id = p.id 
                            JOIN catalogue ct ON p.catalogue_id = ct.id
                            JOIN employees e ON s.employee_id = e.id 
                            WHERE s.fertilized >= CURRENT_date - 7
                            ORDER BY s.id 
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "Полное имя": row[1],
                    "Дата удобрения": row[2],
                    "ФИО сотрудника": row[3],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}
    
    
@router.get("/queries/4", status_code=200)
def query_4(response: Response):
    try:
        with get_cursor() as cursor:
            # Список ухода за последний сезон
            cursor.execute(f"""
                            SELECT s.id, ct.full_name, s.fertilized, CONCAT(e.surname, ' ', LEFT(e.name, 1), '. ', LEFT(e.patronymic, 1), '.') AS employee
                            FROM service s 
                            JOIN plants p ON s.plant_id = p.id 
                            JOIN catalogue ct ON p.catalogue_id = ct.id
                            JOIN employees e ON s.employee_id = e.id 
                            WHERE s.fertilized >= CURRENT_date - 90
                            ORDER BY s.id 
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "Полное имя": row[1],
                    "Дата удобрения": row[2],
                    "ФИО сотрудника": row[3],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}
    
    
@router.get("/queries/5", status_code=200)
def query_5(response: Response):
    try:
        with get_cursor() as cursor:
            # Симметричное внутреннее соединение без условия
            cursor.execute(f"""
                            SELECT e.id, CONCAT(e.surname, ' ', LEFT(e.name, 1), '. ', LEFT(e.patronymic, 1), '.') AS employee, p.position 
                            FROM employees e 
                            JOIN positions p ON e.position_id = p.id 
                            ORDER BY e.id 
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "Полное имя": row[1],
                    "Должность": row[2],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}  
    
    
@router.get("/queries/6", status_code=200)
def query_6(response: Response):
    try:
        with get_cursor() as cursor:
            # Симметричное внутреннее соединение без условия
            cursor.execute(f"""
                            SELECT g.id, g.garden, p.property
                            FROM gardens g
                            INNER JOIN properties p ON g.property_id = p.id
                            ORDER BY g.id
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "Название": row[1],
                    "Тип собственности": row[2],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}    
    
    
@router.get("/queries/7", status_code=200)
def query_7(response: Response):
    try:
        with get_cursor() as cursor:
            # Симметричное внутреннее соединение без условия
            cursor.execute(f"""
                            SELECT g.id, g.garden, c.city
                            FROM gardens g
                            INNER JOIN cities c ON g.city_id = c.id
                            ORDER BY g.id
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "Название": row[1],
                    "Город": row[2],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}            


@router.get("/queries/8", status_code=200)
def query_8(response: Response):
    try:
        with get_cursor() as cursor:
            # Сотрудники, участвующие в уходе
            cursor.execute(f"""
                            SELECT e.id, CONCAT(e.surname, ' ', LEFT(e.name, 1), '. ', LEFT(e.patronymic, 1), '.') AS employee, p.position, s.fertilized
                            FROM employees e 
                            JOIN positions p ON e.position_id = p.id 
                            LEFT JOIN service s ON s.employee_id = e.id
                            ORDER BY e.id 
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "ФИО": row[1],
                    "Должность": row[2],
                    "Дата удобрения": row[3],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"} 
    
    
@router.get("/queries/9", status_code=200)
def query_9(response: Response):
    try:
        with get_cursor() as cursor:
            # Сотрудники, ухаживающие за еще не умершими растениями
            cursor.execute(f"""
                            SELECT e.id, CONCAT(e.surname, ' ', LEFT(e.name, 1), '. ', LEFT(e.patronymic, 1), '.') AS employee, c.full_name, p.death
                            FROM employees e  
                            RIGHT JOIN service s ON s.employee_id = e.id
                            RIGHT JOIN plants p ON s.plant_id = p.id
                            JOIN catalogue c ON p.catalogue_id = c.id
                            WHERE p.death is NULL 
                            ORDER BY e.id 
                            LIMIT 50
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "ФИО": row[1],
                    "Название растения": row[2],
                    "Дата смерти": "null" if row[3] is None else row[3],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}     


@router.get("/queries/10", status_code=200)
def query_10(response: Response):
    try:
        with get_cursor() as cursor:
            # Вывод информации о количестве использованного удобрения за сезон
            cursor.execute(f"""
                            SELECT DISTINCT c.care_product, 
                            (SELECT COUNT(*)
                            FROM service s
                            WHERE s.care_product_id = c.id AND s.fertilized >= CURRENT_date - 90) as "Потрачено"
                            FROM care_products c
                            LEFT JOIN service s ON s.care_product_id = c.id
                            ORDER BY "Потрачено" DESC;
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "Средство ухода": row[0],
                    "Израсходовано": row[1],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"} 
    
    
@router.get("/queries/11", status_code=200)
def query_11(response: Response):
    try:
        with get_cursor() as cursor:
            # Вывод количества видов в семействах
            cursor.execute(f"""
                            SELECT f.family, COUNT(*) as "Виды"
                            FROM generas g
                            INNER JOIN families f ON g.family_id = f.id
                            GROUP BY f.family 
                            ORDER BY "Виды" DESC
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "Семейство": row[0],
                    "Кол-во видов": row[1],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"} 
    
    
@router.get("/queries/12", status_code=200)
def query_12(response: Response):
    try:
        with get_cursor() as cursor:
            # Вывод информации о количестве садов с финансированием и без
            cursor.execute(f"""
                            SELECT count(*), count(CASE WHEN financing = true THEN id END),
                            count(CASE WHEN financing = false THEN id END)
                            FROM gardens
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "Общее кол-во садов": row[0],
                    "С финансированием": row[1],
                    "Без финансирования": row[2],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}  
    

@router.get("/queries/13", status_code=200)
def query_13(response: Response):
    try:
        with get_cursor() as cursor:
            # Количество опр. типа собственности за период после 2010г.
            cursor.execute(f"""
                            SELECT p.property, COUNT(g.property_id)
                            FROM gardens g 
                            INNER JOIN properties p ON g.property_id = p.id
                            WHERE opening > 2010
                            GROUP BY p.property
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "Тип собственности": row[0],
                    "Кол-во садов": row[1],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}    
    
    
@router.get("/queries/14", status_code=200)
def query_14(response: Response):
    try:
        with get_cursor() as cursor:
            # Количество растений, обслуживаемых Владимирами
            cursor.execute(f"""
                            SELECT e.id, e.surname, e.name, count(s.*) 
                            FROM service s
                            JOIN employees e ON s.employee_id = e.id
                            GROUP BY e.id, e.surname, e.name
                            HAVING e.name ILIKE 'Владимир%'
                            ORDER BY e.id ASC
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "Фамилия": row[1],
                    "Имя": row[2],
                    "Кол-во": row[3],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"} 
    
    
@router.get("/queries/15", status_code=200)
def query_15(response: Response):
    try:
        with get_cursor() as cursor:
            # Получить количество садов в каждом городе и указать максимальное открытие среди них
            cursor.execute(f"""
                            SELECT 
                                c.city,
                                COUNT(g.id) AS garden_count,
                                MAX(g.opening) AS max_opening
                            FROM gardens g
                            JOIN cities c ON g.city_id = c.id
                            GROUP BY c.city;
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "Город": row[0],
                    "Кол-во садов": row[1],
                    "Самое позднее открытие": row[2],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"} 
    
    
@router.get("/queries/16", status_code=200)
def query_16(response: Response):
    try:
        with get_cursor() as cursor:
            # Количество растений определенного вида
            cursor.execute(f"""
                            SELECT g.genera, COUNT(*) as "Кол-во растений"
                            FROM plants p
                            JOIN catalogue c ON p.catalogue_id = c.id
                            JOIN generas g ON c.genera_id = g.id
                            GROUP BY p.death, g.genera
                            HAVING p.death is NULL
                            ORDER BY "Кол-во растений" DESC
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "Вид": row[0],
                    "Кол-во": row[1],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}   
    
    
@router.get("/queries/17", status_code=200)
def query_17(response: Response):
    try:
        with get_cursor() as cursor:
            # Количество растений определенного вида, которые вымерли
            cursor.execute(f"""
                            SELECT g.genera, COUNT(*) as "Кол-во растений"
                            FROM plants p
                            JOIN catalogue c ON p.catalogue_id = c.id
                            JOIN generas g ON c.genera_id = g.id
                            WHERE p.death IS NOT NULL
                            GROUP BY g.genera
                            ORDER BY "Кол-во растений" DESC
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "Вид": row[0],
                    "Кол-во": row[1],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"} 
    
    
@router.get("/queries/18", status_code=200)
def query_18(response: Response):
    try:
        with get_cursor() as cursor:
            # Cредняя стоимость саженцев не превышает 888
            cursor.execute(f"""
                            SELECT c.full_name, round(avg(p.price), 3) as "AVG"
                            FROM plants p 
                            INNER JOIN catalogue c ON p.catalogue_id = c.id
                            GROUP BY c.full_name
                            HAVING avg(p.price) < 888
                            ORDER BY "AVG" DESC
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "Название": row[0],
                    "Средняя цена": row[1],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"} 
    
    
@router.get("/queries/19", status_code=200)
def query_19(response: Response):
    try:
        with get_cursor() as cursor:
            # Количество растений за удобренных за 90 дней, превышающих 2
            cursor.execute(f"""
                            SELECT CONCAT(e.surname, ' ', LEFT(e.name, 1), '. ', LEFT(e.patronymic, 1), '.') AS employee, COUNT(s.*)
                            FROM service s
                            RIGHT JOIN employees e ON s.employee_id = e.id
                            WHERE s.fertilized >= CURRENT_date - 90
                            GROUP BY employee
                            HAVING count(s.id) > 2
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "ФИО": row[0],
                    "Кол-во": row[1],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}
    
    
@router.get("/queries/20", status_code=200)
def query_20(response: Response):
    try:
        with get_cursor() as cursor:
            # Кол-во политых растениях каждым сотрудником
            cursor.execute(f"""
                            SELECT DISTINCT
                            CONCAT(e.surname, ' ', LEFT(e.name, 1), '. ', LEFT(e.patronymic, 1), '.') AS employee,
                            e.birth,
                            (SELECT COUNT(*) FROM service s WHERE s.employee_id = e.id) AS "1" FROM employees e
                            ORDER BY "1" DESC;
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "ФИО": row[0],
                    "Дата рождения": row[1],
                    "Кол-во": row[2],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}
    
    
@router.get("/queries/21", status_code=200)
def query_21(response: Response):
    try:
        with get_cursor() as cursor:
            # Инф. о Работниках с опытом работы более 2 лет и их обслуживании.
            cursor.execute(f"""
                            SELECT id, CONCAT(employees.surname, ' ', LEFT(employees.name, 1), '. ', LEFT(employees.patronymic, 1), '.') AS employee, 
                            experience, NULL AS service_info
                            FROM employees
                            WHERE experience > 2
                            UNION
                            SELECT employees.id, CONCAT(employees.surname, ' ', LEFT(employees.name, 1), '. ', LEFT(employees.patronymic, 1), '.') AS employee, 
                            employees.experience, 
                            service.amount || ' разных растений обслуживается ' AS service_info
                            FROM employees
                            JOIN service ON employees.id = service.employee_id 
                            JOIN plants ON service.plant_id = plants.id
                            WHERE employees.experience > 2;
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "ФИО": row[1],
                    "Опыт работы": row[2],
                    "Обслуживание": "null" if row[3] is None else row[3],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}

      
@router.get("/queries/22", status_code=200)
def query_22(response: Response):
    try:
        with get_cursor() as cursor:
            # Дата удобрения растения с сроком жизни больше 5 лет
            cursor.execute(f"""
                            SELECT 
                            s.fertilized,
                            cat.full_name,
                            cat.life_span
                            FROM service s
                            JOIN plants p ON s.plant_id = p.id
                            JOIN catalogue cat ON p.catalogue_id = cat.id
                            WHERE cat.life_span > 5
                            AND p.id IN (SELECT plant_id FROM service);
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "Дата": row[0],
                    "Полное название": row[1],
                    "Срок жизни": row[2],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}     
    
    
@router.get("/queries/23", status_code=200)
def query_23(response: Response):
    try:
        with get_cursor() as cursor:
            # Растения без обслуживания и обслуживающих сотрудников
            cursor.execute(f"""
                            SELECT 
                                p.id,
                                c.full_name,
                                p.planting,
                                p.death
                            FROM plants p
                            JOIN catalogue c ON p.catalogue_id = c.id
                            LEFT JOIN service s ON p.id = s.plant_id
                            LEFT JOIN employees e ON s.employee_id = e.id
                            WHERE p.id NOT IN (SELECT plant_id FROM service WHERE plant_id IS NOT NULL)
                            ORDER BY p.id
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "Полное название": row[1],
                    "Дата посадки": row[2],
                    "Дата гибели": row[3],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}  
    
    
@router.get("/queries/24", status_code=200)
def query_24(response: Response):
    try:
        with get_cursor() as cursor:
            # Получить список сотрудников, их должности и указать "Молодой" или "Опытный" в зависимости от опыта работы
            cursor.execute(f"""
                            SELECT 
                                e.id AS employee_id,
                                CONCAT(e.surname, ' ', LEFT(e.name, 1), '. ', LEFT(e.patronymic, 1), '.') AS employee,
                                p.position,
                                e.experience,
                                CASE 
                                    WHEN e.experience <= 5 THEN 'Молодой'
                                    ELSE 'Опытный'
                                END AS experience_category
                            FROM employees e
                            JOIN positions p ON e.position_id = p.id;
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "КОД": row[0],
                    "ФИО": row[1],
                    "Должность": row[2],
                    "Опыт": row[3],
                    "Оценка опыта": row[4],
                    
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}  
      
      
@router.get("/queries/25", status_code=200)
def query_25(response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT g.garden, 
                            COUNT(p.*) AS percentage 
                            FROM plants p 
                            RIGHT JOIN service s ON p.id = s.plant_id 
                            INNER JOIN employees e ON s.employee_id = e.id 
                            INNER JOIN gardens g ON e.id = g.employee_id 
                            WHERE p.planting < '2020-01-01' GROUP BY g.garden;
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "garden": row[0],
                    "percentage": row[1],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@router.get("/queries/26", status_code=200)
def query_26(response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT g.garden as "Сад",
                            round (avg(extract('year' FROM age (current_date, e.birth)))) as "Cредний возраст сотрудников",
                            round (avg(e.experience), 1) as "Средний стаx сотрудников"
                            FROM gardens g
                            JOIN employees e ON g.employee_id = e.id
                            GROUP BY g.garden;
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "Сад": row[0],
                    "Cредний возраст сотрудников": row[1],
                    "Средний стаx сотрудников": row[2],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}


@router.get("/queries/27", status_code=200)
def query_27(response: Response):
    try:
        with get_cursor() as cursor:
            cursor.execute(f"""
                            SELECT g.garden, 
                            COUNT(p.*) AS "Количество растений", SUM((SELECT s.amount)) AS "Расходы по уходу за растениями" 
                            FROM service s 
                            RIGHT JOIN plants p ON s.plant_id = p.id 
                            INNER JOIN employees e ON s.employee_id = e.id 
                            INNER JOIN gardens g ON e.id = g.employee_id 
                            GROUP BY g.garden;
                            """)
            result = []
            rows_list = cursor.fetchall()
            for row in rows_list:
                result.append({
                    "garden": row[0],
                    "Количество растений": row[1],
                    "Расходы по уходу за растениями": row[2],
                })
            response.status_code = status.HTTP_200_OK
            return {"rows": result}
    except Exception as e:
        response.status_code = status.HTTP_500_INTERNAL_SERVER_ERROR
        return {"error": f"Возникла необработанная ошибка: {e}"}
