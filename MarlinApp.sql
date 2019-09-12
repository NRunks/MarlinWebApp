CREATE TABLE tblUser(
User_ID int,
User_Name Varchar(255),
User_Email Varchar(255),
User_Image Varchar(255),
User_Password Varchar(255)
);

CREATE TABLE tblManufacturer(
Manufacturer_ID int,
Manufacturer_Name Varchar(255),
Manufacturer_Department Varchar(255),
Manufacturer_Web Varchar(255),
User_ID int
);

CREATE TABLE tblDepartment(
Department_ID int,
Manufacturer_ID int,
Department_Name Varchar(255),
Department_Phone int,
Department_Email Varchar(255),
);

CREATE TABLE tblPropertyValue(
Property_ID int NOT NULL,
Product_ID int  NOT NULL,
value int,
PRIMARY KEY (Property_ID,Product_ID)
);

CREATE TABLE tblProduct(
Product_ID int,
Manufacturer_ID int,
Sales_ID int,
SubCategory_ID int,
Product_Name Varchar(255),
Product_Image Varchar(255),
Series Varchar(255),
Model Varchar(255),
Model_Year int,
Series_Infro Varchar(255),
Document_ID int,
Featured Varchar(255),
);

CREATE TABLE tblSales(
Sales_ID int,
Sales_Name Varchar(255),
Sales_Phone int,
Sales_Email Varchar(255),
Sales_Web Varchar(255),
);

CREATE TABLE tblCategory(
Category_ID int,
Category_Name Varchar(255),
);

CREATE TABLE tblSubCategory(
SubCategory_ID int,
Category_ID int,
SubCategory_Name Varchar(255),
);

CREATE TABLE tblTypeFilter(
Property_ID int not null,
SubCategory_ID int not null,
Type_Name Varchar(255),
Type_Options int
Primary key(Property_ID, SubCategory_ID)
);

CREATE TABLE tblProperty(
Property_ID int,
Property_Name Varchar(255),
IsType Varchar(255),
IsTechSpec Varchar(255)
);

CREATE TABLE tblDocument(
Document_ID int,
Document_Folder_Path Varchar(255)
);

CREATE TABLE tblTechSpecFilter(
Property_ID int Not NULL,
SubCategory_ID int NOT NULL,
Min_Value int,
Max_Value int
PRIMARY KEY(Property_ID,SubCategory_ID)
);


ALTER TABLE tblUser ALTER COLUMN User_ID INTEGER NOT NULl
ALTER TABLE tblDepartment ALTER COLUMN Department_ID INTEGER NOT NULl
ALTER TABLE tblManufacturer ALTER COLUMN Manufacturer_ID INTEGER NOT NULl
ALTER TABLE tblProduct ALTER COLUMN Product_ID INTEGER NOT NULl
ALTER TABLE tblSales ALTER COLUMN Sales_ID INTEGER NOT NULl
ALTER TABLE tblCategory ALTER COLUMN Category_ID INTEGER NOT NULl
ALTER TABLE tblDocument ALTER COLUMN Document_ID INTEGER NOT NULl
ALTER TABLE tblProperty ALTER COLUMN Property_ID INTEGER NOT NULl
ALTER TABLE tblPropertyValue ALTER COLUMN Property_ID INTEGER NOT NULl
ALTER TABLE tblPropertyValue ALTER COLUMN Product_ID INTEGER NOT NULl
ALTER TABLE tblTypeFilter ALTER COLUMN Property_ID INTEGER NOT NULl
ALTER TABLE tblTypeFilter ALTER COLUMN SubCategory_ID INTEGER NOT NULl
ALTER TABLE tblTechSpecFilter ALTER COLUMN Property_ID INTEGER NOT NULl
ALTER TABLE tblTechSpecFilter ALTER COLUMN SubCategory_ID INTEGER NOT NULl
ALTER TABLE tblSubCategory ALTER COLUMN SubCategory_ID INTEGER NOT NULl




ALTER TABLE tblUser
ADD PRIMARY KEY (User_ID);

ALTER TABLE tblManufacturer
ADD PRIMARY KEY (Manufacturer_ID);

ALTER TABLE tblDepartment
ADD PRIMARY KEY (Department_ID);

ALTER TABLE tblProduct
ADD PRIMARY KEY (Product_ID);

ALTER TABLE tblCategory
ADD PRIMARY KEY (Category_ID);

ALTER TABLE tblDocument
ADD PRIMARY KEY (Document_ID);

ALTER TABLE tblProperty
ADD PRIMARY KEY (Property_ID);

ALTER TABLE tblSales
ADD PRIMARY KEY (Sales_ID);

ALTER TABLE tblSubCategory
ADD PRIMARY KEY (SubCategory_ID);



Alter table tblManufacturer add constraint tblManufacturer_User_ID_FK
Foreign Key (User_ID) references tblUser(User_ID)

Alter table tblDepartment add constraint tblDepartment_Manufacturer_ID_FK
Foreign Key (Manufacturer_ID) references tblManufacturer(Manufacturer_ID)

Alter table tblProduct add constraint tblProduct_Manufacturer_ID_FK
Foreign Key (Manufacturer_ID) references tblManufacturer(Manufacturer_ID)

Alter table tblProduct add constraint tblProduct_Sales_ID_FK
Foreign Key (Sales_ID) references tblSales(Sales_ID)

Alter table tblProduct add constraint tblProduct_SubCategory_ID_FK
Foreign Key (SubCategory_ID) references tblSubCategory(SubCategory_ID)

Alter table tblProduct add constraint tblProduct_Document_ID_FK
Foreign Key (Document_ID) references tblDocument(Document_ID)

Alter table tblSubCategory add constraint tblSubCategory_Category_ID_FK
Foreign Key (Category_ID) references tblCategory(Category_ID)

Alter table tblTechSpecFilter add constraint tblTechSpecFilter_Property_ID_FK
Foreign Key (Property_ID) references tblProperty(Property_ID)

Alter table tblTechSpecFilter add constraint tblTechSpecFilter_SubCategory_ID_FK
Foreign Key (SubCategory_ID) references tblSubCategory(SubCategory_ID)

Alter table tblTypeFilter add constraint tblTypeFilter_Property_ID_FK
Foreign Key (Property_ID) references tblProperty(Property_ID)

Alter table tblTypeFilter add constraint tblTypeFilter_SubCategory_ID_FK
Foreign Key (SubCategory_ID) references tblSubCategory(SubCategory_ID)

Alter table tblPropertyValue add constraint tblPropertyValue_Property_ID_FK
Foreign Key (Property_ID) references tblProperty(Property_ID)

Alter table tblPropertyValue add constraint tblPropertyValue_Product_ID_FK
Foreign Key (Product_ID) references tblProduct(Product_ID)


