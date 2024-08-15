-- Admin Table
DROP TABLE IF EXISTS user_profile;

CREATE TABLE  user_profile (
    ID uniqueidentifier NOT NULL PRIMARY KEY,
	Fullname VARCHAR(50),
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,        -- Increased length for storing hashed passwords
    email VARCHAR(100),                    -- Email address for contact and notifications
    phone VARCHAR(15),                     -- Phone number for contact purposes
    status VARCHAR(10) DEFAULT 'active',   -- Status of the admin account, e.g., active, inactive
    last_login DATETIME,                   -- Last login timestamp
    failed_attempts INT DEFAULT 0,         -- Counter for failed login attempts
    created_by uniqueidentifier,                        -- ID of the admin who created this account
    updated_by uniqueidentifier,                        -- ID of the admin who last updated this account
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,   -- Timestamp for when the admin was created
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP -- Timestamp for last update
);

DROP TABLE IF EXISTS audit;

CREATE TABLE audit (
    ID uniqueidentifier NOT NULL PRIMARY KEY,
    user_id uniqueidentifier FOREIGN KEY REFERENCES user_profile(ID), -- User performing the action
    action_type VARCHAR(10) NOT NULL,    -- Type of action: 'INSERT', 'UPDATE', 'DELETE'
    table_name VARCHAR(50) NOT NULL,     -- Name of the affected table
    record_id uniqueidentifier,          -- ID of the affected record, if applicable
    timestamp DATETIME DEFAULT CURRENT_TIMESTAMP, -- Time of the action
    ip_address VARCHAR(45),              -- IP address of the user
    device_info VARCHAR(255),            -- Device information
    details VARCHAR(MAX)                 -- Additional details about the action
);


-- User Log Table
DROP TABLE IF EXISTS User_login_history;

CREATE TABLE  User_login_history (
    ID uniqueidentifier NOT NULL PRIMARY KEY,
	user_id uniqueidentifier FOREIGN KEY REFERENCES user_profile(ID) ,
    session_started DATETIME DEFAULT CURRENT_TIMESTAMP,  -- Timestamp for when the session started
    session_end DATETIME,                             -- Timestamp for when the session ended
    ip_address VARCHAR(45),                           -- IP address of the user
    device_info VARCHAR(255),                         -- Information about the user's device
    session_duration INT , -- Duration of the session in minutes
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,    -- Timestamp for when the record was created
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP  -- Timestamp for last update
);

-- Task Table
DROP TABLE IF EXISTS action_caticory;

CREATE TABLE action_caticory (
    ID uniqueidentifier NOT NULL PRIMARY KEY,
    caticory VARCHAR(100) NOT NULL,   -- Corrected column name spelling
    description VARCHAR(255),          -- Detailed description of the task
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP  -- Timestamp for when the task was created
);

DROP TABLE IF EXISTS action;

CREATE TABLE action (
    ID uniqueidentifier NOT NULL PRIMARY KEY,
    caticory_id uniqueidentifier FOREIGN KEY REFERENCES action_caticory(ID) ,
    action_description VARCHAR(255),          -- Detailed description of the task
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP  -- Timestamp for when the task was created
);

-- User Task Table
DROP TABLE IF EXISTS user_permission;

CREATE TABLE user_permission (
    ID uniqueidentifier NOT NULL PRIMARY KEY,
    action_id uniqueidentifier FOREIGN KEY REFERENCES action(ID) ,
    action_active BIT DEFAULT 0,    -- Use BIT for boolean values
    user_id uniqueidentifier FOREIGN KEY REFERENCES action(ID) ,
    FOREIGN KEY (user_id) REFERENCES user_profile(id),
    assigned_at DATETIME DEFAULT CURRENT_TIMESTAMP,  -- Timestamp for when the task was assigned
);

DROP TABLE IF EXISTS Currencies;


CREATE TABLE Currencies (
    CurrencyID INT PRIMARY KEY IDENTITY(1,1),
    CurrencyCode CHAR(3) NOT NULL,  -- ISO 4217 currency code (e.g., USD, EUR, JPY)
    CurrencyName VARCHAR(100) NOT NULL,
    Symbol CHAR(1) NULL,            -- Symbol for the currency (e.g., $, €, ¥)
    CONSTRAINT UQ_CurrencyCode UNIQUE (CurrencyCode)  -- Ensures each currency code is unique
);

-- Insert all Arab currencies including Syria into Currencies table
INSERT INTO Currencies (CurrencyCode, CurrencyName, Symbol)
VALUES ('SAR', 'Saudi Riyal', 'ر.س'),
       ('AED', 'United Arab Emirates Dirham', 'د.إ'),
       ('EGP', 'Egyptian Pound', 'ج.م'),
       ('IQD', 'Iraqi Dinar', 'ع.د'),
       ('JOD', 'Jordanian Dinar', 'د.أ'),
       ('KWD', 'Kuwaiti Dinar', 'د.ك'),
       ('OMR', 'Omani Rial', 'ر.ع.'),
       ('BHD', 'Bahraini Dinar', 'د.ب'),
       ('LYD', 'Libyan Dinar', 'ل.د'),
       ('MAD', 'Moroccan Dirham', 'د.م.'),
       ('DZD', 'Algerian Dinar', 'د.ج'),
       ('TND', 'Tunisian Dinar', 'د.ت'),
       ('MRU', 'Ouguiya', 'أ.م'),
       ('JOD', 'Jordanian Dinar', 'د.أ'), 
       ('SYP', 'Syrian Pound', 'ل.س');

INSERT INTO Currencies (CurrencyCode, CurrencyName, Symbol)
VALUES ('USD', 'United States Dollar', '$'),
       ('EUR', 'Euro', '€'),
       ('JPY', 'Japanese Yen', '¥');

DROP TABLE IF EXISTS ExchangeRates;
CREATE TABLE ExchangeRates (
    RateID uniqueidentifier PRIMARY KEY ,
    CurrencyID INT NOT NULL,
    ExchangeRate DECIMAL(18, 6) NOT NULL,  -- Exchange rate relative to USD
    Date DATE NOT NULL,                   -- Date of the exchange rate
    CONSTRAINT FK_Currency FOREIGN KEY (CurrencyID) REFERENCES Currencies(CurrencyID),
    CONSTRAINT UQ_Currency_Date UNIQUE (CurrencyID, Date)  -- Ensures only one rate per currency per date
);




DROP TABLE IF EXISTS company;

CREATE TABLE company(
id uniqueidentifier  NOT NULL PRIMARY KEY ,
name VARCHAR(30) NOT NULL,
street VARCHAR(MAX) NOT NULL,
city VARCHAR(150) NOT NULL,
country VARCHAR(30) NOT NULL,
phone VARCHAR(30) NOT NULL,
email VARCHAR(50) NOT NULL,
web_site VARCHAR(60) NOT NULL,
logo IMAGE,
FK_Currency int FOREIGN KEY REFERENCES Currencies(CurrencyID),
);

ALTER TABLE company ADD active VARCHAR(6) DEFAULT 'false';
ALTER TABLE company ADD block_Date DATETIME;
ALTER TABLE company ADD MainBranch bit;
ALTER TABLE company ADD code varchar(10);





DROP TABLE IF EXISTS material_group;

CREATE TABLE material_group(
رقم_المجموعة uniqueidentifier NOT NULL PRIMARY KEY,
اسم_المجموعة VARCHAR(100) NOT NULL DEFAULT ''
);
ALTER TABLE material_group ADD companyID uniqueidentifier;


DROP TABLE IF EXISTS producer;

CREATE TABLE producer(
رقم_الصانع uniqueidentifier NOT NULL PRIMARY KEY,
اسم_الصانع VARCHAR(60) NOT NULL DEFAULT '',
رمز_النوع VARCHAR(50) NOT NULL DEFAULT ''
);
ALTER TABLE producer ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS WareHouse;

CREATE TABLE WareHouse(
رقم_المستودع uniqueidentifier NOT NULL PRIMARY KEY,
اسم_المستودع VARCHAR(50) NOT NULL DEFAULT ''
);
ALTER TABLE WareHouse ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS material;

CREATE TABLE material(
الرقم_الفني uniqueidentifier NOT NULL PRIMARY KEY ,
اسم_المادة VARCHAR(100) NOT NULL,
تواجد_المادة VARCHAR(50),
الوحدة VARCHAR(20) NOT NULL,
كمية INT NOT NULL DEFAULT 0,
سعر FLOAT NOT NULL DEFAULT 0,
رمز_الطراز VARCHAR(30),
المجموعة uniqueidentifier FOREIGN KEY REFERENCES material_group(رقم_المجموعة) ,
الصانع uniqueidentifier FOREIGN KEY REFERENCES producer(رقم_الصانع) ,
المستودع uniqueidentifier FOREIGN KEY REFERENCES WareHouse(رقم_المستودع) 
);

ALTER TABLE material ADD بالة VARCHAR(6) DEFAULT 'false';
ALTER TABLE material ADD وصف_المادة VARCHAR(MAX);
ALTER TABLE material ADD صورة VARCHAR(100);
ALTER TABLE material ADD فرق_السعر INT DEFAULT 0;
ALTER TABLE material ADD فرق_الكمية INT DEFAULT 0;
ALTER TABLE material ADD سعر_الشراء INT DEFAULT 0;
ALTER TABLE material ADD سعر_البيع INT DEFAULT 0;
ALTER TABLE material ADD كود_المادة VARCHAR(30) DEFAULT '';
ALTER TABLE material ADD طريقة_حساب_الكلفة VARCHAR(10);
ALTER TABLE material ADD companyID uniqueidentifier;
ALTER TABLE material ADD BoxColor VARCHAR(25);


DROP TABLE IF EXISTS material_cost;

CREATE TABLE material_cost(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
المادة uniqueidentifier FOREIGN KEY REFERENCES material(الرقم_الفني),
سعر_الشراء INT NOT NULL,
كمية INT NOT NULL DEFAULT 0,
التاريخ DATETIME
);
ALTER TABLE material_cost ADD رقم_فاتورة_الشراء uniqueidentifier;
ALTER TABLE material_cost ADD companyID uniqueidentifier;



DROP TABLE IF EXISTS customer;

CREATE TABLE customer(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
اسم_الزبون VARCHAR(50) NOT NULL UNIQUE,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
عنوان_الزبون VARCHAR(100),
هاتف VARCHAR(20),
الموبايل VARCHAR(20),
البريد_الالكتروني VARCHAR(50),
تاريخ DATETIME,
وصف_الزبون VARCHAR(MAX),
صورة IMAGE
);
ALTER TABLE customer ADD code varchar(10);
ALTER TABLE customer ADD companyID uniqueidentifier;

-- Insert a row into the customer table
INSERT INTO [dbo].[customer]
           ([الرقم]
           ,[اسم_الزبون]
           ,[الرصيد]
           ,[الرصيد_كتابة]
           ,[عنوان_الزبون]
           ,[هاتف]
           ,[الموبايل]
           ,[البريد_الالكتروني]
           ,[تاريخ]
           ,[وصف_الزبون]
           ,[صورة]
           ,[code]
           ,[companyID])
VALUES
           (NEWID(),       -- الرقم
           'غير معروف',   -- اسم_الزبون
           0,             -- الرصيد
           'صفر',         -- الرصيد_كتابة
           '',            -- عنوان_الزبون
           '',            -- هاتف
           '',            -- الموبايل
           '',            -- البريد_الالكتروني
           GETDATE(),     -- تاريخ
           '',            -- وصف_الزبون
           NULL,          -- صورة
           NULL,          -- code
           NULL           -- companyID
           );

DROP TABLE IF EXISTS customer_debit;

CREATE TABLE customer_debit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT 'توريد بضاعة لعميل',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
customer_id uniqueidentifier FOREIGN KEY REFERENCES customer(الرقم)
);

DROP TABLE IF EXISTS customer_credit;

CREATE TABLE customer_credit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT 'تسديد قيمة البضاعة',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
customer_id uniqueidentifier FOREIGN KEY REFERENCES customer(الرقم)
);

CREATE TABLE customer_ReveiveTime(
الرقم INT NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
customer_id uniqueidentifier FOREIGN KEY REFERENCES customer(الرقم)
);

ALTER TABLE customer_ReveiveTime ADD تم_الدفع VARCHAR(10) DEFAULT 'false';

DROP TABLE IF EXISTS supplier;

CREATE TABLE supplier(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
اسم_المورد VARCHAR(50) NOT NULL UNIQUE,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
عنوان_المورد VARCHAR(100),
هاتف VARCHAR(20),
الموبايل VARCHAR(20),
البريد_الالكتروني VARCHAR(50),
الموقع_الالكتروني VARCHAR(50),
تاريخ DATETIME,
وصف_المورد VARCHAR(MAX),
صورة IMAGE
);
ALTER TABLE supplier ADD code varchar(10);
ALTER TABLE supplier ADD companyID uniqueidentifier;


INSERT INTO [supplier]
           (الرقم
		   ,[اسم_المورد]
           ,[الرصيد]
           ,[الرصيد_كتابة]
           ,[عنوان_المورد]
           ,[هاتف]
           ,[الموبايل]
           ,[البريد_الالكتروني]
           ,[الموقع_الالكتروني]
           ,[تاريخ]
           ,[وصف_المورد]
           ,[صورة] 
		   ,[code]
           ,[companyID])
     VALUES
           (NEWID()
		   ,'غير معروف'
           ,0
           ,'صفر'
           ,''
           ,''
           ,''
           ,''
           ,''
           ,GETDATE()
           ,''
           ,null,null,null);

DROP TABLE IF EXISTS supplier_debit;

CREATE TABLE supplier_debit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT 'توريد مبلغ للمورد',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
Supplier_id uniqueidentifier FOREIGN KEY REFERENCES supplier(الرقم)
);

DROP TABLE IF EXISTS supplier_credit;

CREATE TABLE supplier_credit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT 'استيراد بضاعة من المورد',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
Supplier_id uniqueidentifier FOREIGN KEY REFERENCES supplier(الرقم)
);

CREATE TABLE supplier_PayTime(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
Supplier_id uniqueidentifier FOREIGN KEY REFERENCES supplier(الرقم)
);

ALTER TABLE supplier_PayTime ADD تم_الدفع VARCHAR(10) DEFAULT 'false';

DROP TABLE IF EXISTS material_debit;

CREATE TABLE material_debit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
تاريخ DATETIME NOT NULL,
الرصيد FLOAT NOT NULL,
من VARCHAR(100),
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
رقم_فاتورة_المصدر INT,
تاريخ_فاتورة_المصدر DATETIME,
المصدر VARCHAR(40),
المستودع VARCHAR(10),
المورد uniqueidentifier NOT NULL FOREIGN KEY REFERENCES supplier(الرقم)
);

ALTER TABLE material_debit ADD حذفة VARCHAR(5) DEFAULT '';
ALTER TABLE material_debit ADD نوع_العملية VARCHAR(10) DEFAULT 'شراء';
ALTER TABLE material_debit ADD حسام_مكتسب FLOAT DEFAULT 0;
ALTER TABLE material_debit ADD مصاريف_مضافة FLOAT DEFAULT 0;
ALTER TABLE material_debit ADD مصاريف_على_حساب VARCHAR(20);
ALTER TABLE material_debit ADD مرحل VARCHAR(5);
ALTER TABLE material_debit ADD طريقة_الدفع VARCHAR(10);
ALTER TABLE material_debit ADD اسم_الحساب VARCHAR(30);
ALTER TABLE material_debit ADD سند_الدفع INT DEFAULT 0;
ALTER TABLE material_debit ADD code varchar(10);
ALTER TABLE material_debit ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS material_debit_list;

CREATE TABLE material_debit_list(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
رقم_المادة uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_التقرير uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material_debit(الرقم),
اسم_المادة VARCHAR(100) NOT NULL,
الوحدة VARCHAR(20) NOT NULL,
كمية INT NOT NULL,
السعر FLOAT NOT NULL,
السعر_الجمالي FLOAT NOT NULL,
ملاحظات VARCHAR(50)
);

ALTER TABLE material_debit_list ADD المستودع INT;
ALTER TABLE material_debit_list ADD كمية_كتابة VARCHAR(50);
ALTER TABLE material_debit_list ADD حذفة VARCHAR(5) DEFAULT '';
ALTER TABLE material_debit_list ADD حسام_مكتسب FLOAT DEFAULT 0;

DROP TABLE IF EXISTS material_debit_penfit_payment;

CREATE TABLE material_debit_penfit_payment(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
رقم_التقرير uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material_debit(الرقم),
الفائدة INT NOT NULL,
نسبة_الفائدة INT NOT NULL,
الدفع_كل INT NOT NULL,
عدد_الأقساط INT NOT NULL
);

ALTER TABLE material_debit_penfit_payment ADD العربون INT DEFAULT 0;

DROP TABLE IF EXISTS material_debit_return;

CREATE TABLE material_debit_return(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
تاريخ DATETIME NOT NULL,
الرصيد FLOAT NOT NULL,
من VARCHAR(100),
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
رقم_فاتورة_المصدر INT,
تاريخ_فاتورة_المصدر DATETIME,
المصدر VARCHAR(40),
المستودع VARCHAR(10),
العميل uniqueidentifier NOT NULL FOREIGN KEY REFERENCES customer(الرقم)
);

ALTER TABLE material_debit_return ADD حذفة VARCHAR(5) DEFAULT '';
ALTER TABLE material_debit_return ADD نوع_العملية VARCHAR(10) DEFAULT 'شراء';
ALTER TABLE material_debit_return ADD حسام_مكتسب FLOAT DEFAULT 0;
ALTER TABLE material_debit_return ADD مصاريف_مضافة FLOAT DEFAULT 0;
ALTER TABLE material_debit_return ADD مصاريف_على_حساب VARCHAR(20);
ALTER TABLE material_debit_return ADD مرحل VARCHAR(5);
ALTER TABLE material_debit_return ADD طريقة_الدفع VARCHAR(10);
ALTER TABLE material_debit_return ADD اسم_الحساب VARCHAR(30);
ALTER TABLE material_debit_return ADD الكلفة FLOAT;
ALTER TABLE material_debit_return ADD code varchar(10);
ALTER TABLE material_debit_return ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS material_debit_list_return;

CREATE TABLE material_debit_list_return(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
رقم_المادة uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_التقرير uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material_debit_return(الرقم),
اسم_المادة VARCHAR(100) NOT NULL,
الوحدة VARCHAR(20) NOT NULL,
كمية INT NOT NULL,
السعر FLOAT NOT NULL,
السعر_الجمالي FLOAT NOT NULL,
ملاحظات VARCHAR(50)
);

ALTER TABLE material_debit_list_return ADD المستودع INT;
ALTER TABLE material_debit_list_return ADD كمية_كتابة VARCHAR(50);
ALTER TABLE material_debit_list_return ADD حذفة VARCHAR(5) DEFAULT '';
ALTER TABLE material_debit_list_return ADD حسام_مكتسب FLOAT DEFAULT 0;
ALTER TABLE material_debit_list_return ADD سعر_الشراء INT;
ALTER TABLE material_debit_list_return ADD الكلفة FLOAT;

DROP TABLE IF EXISTS material_credit;

CREATE TABLE material_credit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY,
تاريخ_البيع DATETIME NOT NULL,
تاريخ_التسليم DATETIME NOT NULL,
الرصيد FLOAT NOT NULL,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100),
طريقة_الدفع VARCHAR(20),
المستودع VARCHAR(10),
العميل uniqueidentifier NOT NULL FOREIGN KEY REFERENCES customer(الرقم)
);

ALTER TABLE material_credit ADD حذفة VARCHAR(5) DEFAULT '';
ALTER TABLE material_credit ADD بالة VARCHAR(5) DEFAULT '';
ALTER TABLE material_credit ADD نوع_العملية VARCHAR(30) DEFAULT 'بيع';
ALTER TABLE material_credit ADD حسام_ممنوح FLOAT DEFAULT 0;
ALTER TABLE material_credit ADD مصاريف_مضافة FLOAT DEFAULT 0;
ALTER TABLE material_credit ADD مصاريف_على_حساب VARCHAR(20);
ALTER TABLE material_credit ADD مرحل VARCHAR(5);
ALTER TABLE material_credit ADD اسم_الحساب VARCHAR(30);
ALTER TABLE material_credit ADD سند_القبض INT DEFAULT 0;
ALTER TABLE material_credit ADD الفائدة INT DEFAULT 0;
ALTER TABLE material_credit ADD الدفع_كل INT DEFAULT 0;
ALTER TABLE material_credit ADD عدد_الأقساط INT DEFAULT 0;
ALTER TABLE material_credit ADD الكلفة FLOAT;
ALTER TABLE material_credit ADD code varchar(10);
ALTER TABLE material_credit ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS material_credit_list;

CREATE TABLE material_credit_list(
الرقم uniqueidentifier NOT NULL PRIMARY KEY,
رقم_المادة uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_التقرير uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material_credit(الرقم),
اسم_المادة VARCHAR(100) NOT NULL,
الوحدة VARCHAR(20) NOT NULL,
كمية INT NOT NULL,
السعر FLOAT NOT NULL,
السعر_الجمالي FLOAT NOT NULL,
ملاحظات VARCHAR(50)
);

ALTER TABLE material_credit_list ADD المستودع INT;
ALTER TABLE material_credit_list ADD كمية_كتابة VARCHAR(50);
ALTER TABLE material_credit_list ADD حذفة VARCHAR(5) DEFAULT '';
ALTER TABLE material_credit_list ADD حسام_ممنوح FLOAT DEFAULT 0;
ALTER TABLE material_credit_list ADD سعر_الشراء INT;
ALTER TABLE material_credit_list ADD الكلفة FLOAT;

DROP TABLE IF EXISTS material_credit_penfit_payment;

CREATE TABLE material_credit_penfit_payment(
الرقم uniqueidentifier NOT NULL PRIMARY KEY,
رقم_التقرير uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material_credit(الرقم),
الفائدة INT NOT NULL,
نسبة_الفائدة INT NOT NULL,
الدفع_كل INT NOT NULL,
عدد_الأقساط INT NOT NULL
);

ALTER TABLE material_credit_penfit_payment ADD العربون INT DEFAULT 0;

DROP TABLE IF EXISTS material_credit_return;

CREATE TABLE material_credit_return(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
تاريخ_البيع DATETIME NOT NULL,
تاريخ_التسليم DATETIME NOT NULL,
الرصيد FLOAT NOT NULL,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100),
طريقة_الدفع VARCHAR(20),
المستودع VARCHAR(10),
المورد uniqueidentifier NOT NULL FOREIGN KEY REFERENCES supplier(الرقم)
);

ALTER TABLE material_credit_return ADD حذفة VARCHAR(5) DEFAULT '';
ALTER TABLE material_credit_return ADD بالة VARCHAR(5) DEFAULT '';
ALTER TABLE material_credit_return ADD نوع_العملية VARCHAR(30) DEFAULT 'بيع';
ALTER TABLE material_credit_return ADD حسام_ممنوح FLOAT DEFAULT 0;
ALTER TABLE material_credit_return ADD مصاريف_مضافة FLOAT DEFAULT 0;
ALTER TABLE material_credit_return ADD مصاريف_على_حساب VARCHAR(20);
ALTER TABLE material_credit_return ADD مرحل VARCHAR(5);
ALTER TABLE material_credit_return ADD اسم_الحساب VARCHAR(30);
ALTER TABLE material_credit_return ADD code varchar(10);
ALTER TABLE material_credit_return ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS material_credit_list_return;

CREATE TABLE material_credit_list_return(
رقم_المادة uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_التقرير uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material_credit_return(الرقم),
اسم_المادة VARCHAR(100) NOT NULL,
الوحدة VARCHAR(20) NOT NULL,
كمية INT NOT NULL,
السعر FLOAT NOT NULL,
السعر_الجمالي FLOAT NOT NULL,
ملاحظات VARCHAR(50)
);

ALTER TABLE material_credit_list_return ADD المستودع INT;
ALTER TABLE material_credit_list_return ADD كمية_كتابة VARCHAR(50);
ALTER TABLE material_credit_list_return ADD حذفة VARCHAR(5) DEFAULT '';
ALTER TABLE material_credit_list_return ADD حسام_ممنوح FLOAT DEFAULT 0;


DROP TABLE IF EXISTS box;

CREATE TABLE box(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
اسم_الصندوق VARCHAR(20) NOT NULL,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME NOT NULL
);
ALTER TABLE box ADD code varchar(10);
ALTER TABLE box ADD companyID uniqueidentifier;

INSERT INTO [box]
           (الرقم
		   ,[اسم_الصندوق]
           ,[الرصيد]
           ,[الرصيد_كتابة]
           ,[تاريخ])
     VALUES
           (NEWID()
		   ,'صندوق اليومية'
           ,0
           ,'صفر'
           ,CURRENT_TIMESTAMP);

DROP TABLE IF EXISTS box_debit;

CREATE TABLE box_debit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT 'القرض نقدا',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
box_id uniqueidentifier FOREIGN KEY REFERENCES box(الرقم)
);

DROP TABLE IF EXISTS box_credit;

CREATE TABLE box_credit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT 'تسديد نقدا',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
box_id uniqueidentifier FOREIGN KEY REFERENCES box(الرقم)
);

DROP TABLE IF EXISTS bank_details;

CREATE TABLE bank_details(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
اسم_البنك VARCHAR(50) NOT NULL,
عنوان_البنك VARCHAR(100),
هاتف VARCHAR(20),
الموبايل VARCHAR(20),
البريد_الالكتروني VARCHAR(50),
الموقع_الالكتروني VARCHAR(50)
);

ALTER TABLE bank_details ADD تعليق VARCHAR(100);
ALTER TABLE bank_details ADD code varchar(10);
ALTER TABLE bank_details ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS bank_account;

CREATE TABLE bank_account(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
اسم_الحساب VARCHAR(50) NOT NULL,
رقم_الحساب VARCHAR(20) NOT NULL,
نوع_الحساب VARCHAR(30) NOT NULL,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME NOT NULL,
bank_id uniqueidentifier FOREIGN KEY REFERENCES bank_details(الرقم)
);

ALTER TABLE bank_account ADD تعليق VARCHAR(100);

DROP TABLE IF EXISTS bank_debit;

CREATE TABLE bank_debit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT ' ',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
bank_id uniqueidentifier FOREIGN KEY REFERENCES bank_account(الرقم)
);

DROP TABLE IF EXISTS bank_credit;

CREATE TABLE bank_credit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT ' ',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
bank_id uniqueidentifier FOREIGN KEY REFERENCES bank_account(الرقم)
);

DROP TABLE IF EXISTS bonds;

CREATE TABLE bonds(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT ' ',
الى VARCHAR(100) DEFAULT ' ',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME
);

ALTER TABLE bonds ADD مرحل VARCHAR(5);
ALTER TABLE bonds ADD code varchar(10);
ALTER TABLE bonds ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS asset;

CREATE TABLE asset(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
اسم_الأصل VARCHAR(20) NOT NULL,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME NOT NULL
);

ALTER TABLE asset ADD نوع_الأصل VARCHAR(100);
ALTER TABLE asset ADD نسبة_الأهتلاك INT DEFAULT 0;
ALTER TABLE asset ADD قيمة_النفاية INT DEFAULT 0;
ALTER TABLE asset ADD مجموع_الأهتلاك INT DEFAULT 0;
ALTER TABLE asset ADD code varchar(10);
ALTER TABLE asset ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS asset_debit;

CREATE TABLE asset_debit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
asset_id uniqueidentifier FOREIGN KEY REFERENCES asset(الرقم)
);

DROP TABLE IF EXISTS asset_credit;

CREATE TABLE asset_credit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
asset_id uniqueidentifier FOREIGN KEY REFERENCES asset(الرقم)
);

DROP TABLE IF EXISTS paper_receive;

CREATE TABLE paper_receive(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME,
تاريخ_الاستحقاق DATETIME,
الساحب VARCHAR(50),
المسحوب_عليه VARCHAR(50)
);
ALTER TABLE paper_receive ADD code varchar(10);
ALTER TABLE paper_receive ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS paper_receive_debit;

CREATE TABLE paper_receive_debit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
paper_receive_id uniqueidentifier FOREIGN KEY REFERENCES paper_receive(الرقم)
);

DROP TABLE IF EXISTS paper_receive_credit;

CREATE TABLE paper_receive_credit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
paper_receive_id uniqueidentifier FOREIGN KEY REFERENCES paper_receive(الرقم)
);

DROP TABLE IF EXISTS paper_pay;

CREATE TABLE paper_pay(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME,
تاريخ_الاستحقاق DATETIME,
الساحب VARCHAR(50),
المسحوب_عليه VARCHAR(50)
);
ALTER TABLE paper_pay ADD code varchar(10);
ALTER TABLE paper_pay ADD companyID uniqueidentifier;



DROP TABLE IF EXISTS paper_pay_debit;

CREATE TABLE paper_pay_debit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
paper_receive_id uniqueidentifier FOREIGN KEY REFERENCES paper_pay(الرقم)
);

DROP TABLE IF EXISTS paper_pay_credit;

CREATE TABLE paper_pay_credit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
paper_receive_id uniqueidentifier FOREIGN KEY REFERENCES paper_pay(الرقم)
);

DROP TABLE IF EXISTS liability;


CREATE TABLE liability(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الالتزام VARCHAR(20) NOT NULL,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME NOT NULL
);
ALTER TABLE liability ADD نوع_الالتزام VARCHAR(100);
ALTER TABLE liability ADD نسبة_الفائدة INT DEFAULT 0;
ALTER TABLE liability ADD code varchar(10);
ALTER TABLE liability ADD companyID uniqueidentifier;


DROP TABLE IF EXISTS liability_debit;

CREATE TABLE liability_debit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
liability_id uniqueidentifier FOREIGN KEY REFERENCES liability(الرقم)
);

DROP TABLE IF EXISTS liability_credit;

CREATE TABLE liability_credit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
liability_id uniqueidentifier FOREIGN KEY REFERENCES liability(الرقم)
);

DROP TABLE IF EXISTS error;

CREATE TABLE error(
الرقم INT NOT NULL PRIMARY KEY ,
class VARCHAR(50),
error_ms VARCHAR(MAX),
error_row INT
);

DROP TABLE IF EXISTS material_maker;

CREATE TABLE material_maker(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
اسم_المادة VARCHAR(100) NOT NULL,
الوحدة VARCHAR(20) NOT NULL,
كمية INT NOT NULL DEFAULT 0,
الكلفة FLOAT NOT NULL DEFAULT 0,
سعر_البيع FLOAT NOT NULL DEFAULT 0,
ملاحظات VARCHAR(10),
المجموعة uniqueidentifier FOREIGN KEY REFERENCES material_group(رقم_المجموعة),
);

ALTER TABLE material_maker ADD كلف INT;
ALTER TABLE material_maker ADD code varchar(10);
ALTER TABLE material_maker ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS material_maker_list;

CREATE TABLE material_maker_list(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
رقم_المادة uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_المصنع uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material_maker(الرقم),
كمية INT NOT NULL DEFAULT 0,
سعر_الشراء FLOAT NOT NULL DEFAULT 0,
نسبة_الهدر FLOAT NOT NULL DEFAULT 0,
كلفة_المادة FLOAT NOT NULL DEFAULT 0,
ملاحظات VARCHAR(100) NOT NULL
);

------------
DROP TABLE IF EXISTS materialMaker_credit;

CREATE TABLE materialMaker_credit(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
رقم_المصنع uniqueidentifier FOREIGN KEY REFERENCES material_maker(الرقم),
تاريخ_بداية_التصنيع DATETIME NOT NULL,
تاريخ_نهاية_التصنيع DATETIME NOT NULL,
الكلفة FLOAT NOT NULL,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100),
المستودع uniqueidentifier FOREIGN KEY REFERENCES WareHouse(رقم_المستودع) 
);

ALTER TABLE materialMaker_credit ADD هدر FLOAT DEFAULT 0;
ALTER TABLE materialMaker_credit ADD مصاريف_مضافة FLOAT DEFAULT 0;
ALTER TABLE materialMaker_credit ADD كمية_الانتاج FLOAT DEFAULT 0;
ALTER TABLE materialMaker_credit ADD code varchar(10);
ALTER TABLE materialMaker_credit ADD companyID uniqueidentifier;

DROP TABLE IF EXISTS materialMaker_credit_list;

CREATE TABLE materialMaker_credit_list(
الرقم uniqueidentifier NOT NULL PRIMARY KEY ,
رقم_المادة uniqueidentifier NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_التقرير uniqueidentifier NOT NULL FOREIGN KEY REFERENCES materialMaker_credit(الرقم),
كمية INT NOT NULL,
السعر FLOAT NOT NULL,
السعر_الجمالي FLOAT NOT NULL,
ملاحظات VARCHAR(50)
);

ALTER TABLE materialMaker_credit_list ADD هدر FLOAT DEFAULT 0;

