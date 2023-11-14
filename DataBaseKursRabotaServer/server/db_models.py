from typing import Optional
from pydantic import BaseModel, validator

# Справочники


class Cities(BaseModel):
    city: str


class Properties(BaseModel):
    property: str


class Positions(BaseModel):
    position: str


class Families(BaseModel):
    family: str


class CareProduct(BaseModel):
    care_product: str
    unit: str


# Таблицы


class Genera(BaseModel):
    genera: str
    family_id: int


class Plants(BaseModel):
    photo: str # bytea
    price: int
    planting: str       # date
    death: Optional[str]         # date
    catalogue_id: int
    plot: int
    conditions: str



class Catalogue(BaseModel):
    full_name: str
    life_span: int
    genera_id: int
    annual: bool


class Employees(BaseModel):
    surname: str
    name: str
    patronymic: str
    birth: str      # date
    position_id: int
    experience: int
    salary: int


class Gardens(BaseModel):
    garden: str
    opening: int
    phone: int
    financing: bool
    city_id: int
    property_id: int
    employee_id: int


class Service(BaseModel):
    plant_id: int
    care_product_id: int
    amount: int
    fertilized: str     # date
    employee_id: int
