CREATE TABLE admin_(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
username VARCHAR(50) NOT NULL UNIQUE,
password VARCHAR(50) NOT NULL,
user_type VARCHAR(10)
);

CREATE TABLE Country(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
name VARCHAR(50) NOT NULL UNIQUE
);

DROP TABLE IF EXISTS user_loge;

CREATE TABLE user_loge(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
username VARCHAR(50) NOT NULL UNIQUE,
password VARCHAR(50) NOT NULL,
user_type VARCHAR(10)
);

ALTER TABLE user_loge ADD enable_delete VARCHAR(6) DEFAULT 'No';
ALTER TABLE user_loge ADD remamber VARCHAR(6) DEFAULT 'No';

DROP TABLE IF EXISTS user_task;

CREATE TABLE user_task(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
opreation VARCHAR(100) NOT NULL,
active_opreation VARCHAR(5),
user_id_ INT NOT NULL FOREIGN KEY REFERENCES user_loge(id)
);

DROP TABLE IF EXISTS task;

CREATE TABLE task(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
opreation VARCHAR(100) NOT NULL
);

DROP TABLE IF EXISTS user_loge_date;

CREATE TABLE user_loge_date(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
loge_date_in DATETIME NOT NULL,
user_id_ INT NOT NULL FOREIGN KEY REFERENCES user_loge(id)
);

DROP TABLE IF EXISTS company;

CREATE TABLE company(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
name VARCHAR(30) NOT NULL,
street VARCHAR(MAX) NOT NULL,
city VARCHAR(150) NOT NULL,
country VARCHAR(30) NOT NULL,
phone VARCHAR(30) NOT NULL,
email VARCHAR(50) NOT NULL,
web_site VARCHAR(60) NOT NULL,
logo IMAGE
);

ALTER TABLE company ADD active VARCHAR(6) DEFAULT 'false';
ALTER TABLE company ADD block_Date DATETIME;

DROP TABLE IF EXISTS material_group;

CREATE TABLE material_group(
رقم_المجموعة INT NOT NULL PRIMARY KEY,
اسم_المجموعة VARCHAR(100) NOT NULL DEFAULT ''
);

DROP TABLE IF EXISTS producer;

CREATE TABLE producer(
رقم_الصانع INT NOT NULL PRIMARY KEY,
اسم_الصانع VARCHAR(60) NOT NULL DEFAULT '',
رمز_النوع VARCHAR(50) NOT NULL DEFAULT ''
);

DROP TABLE IF EXISTS WareHouse;

CREATE TABLE WareHouse(
رقم_المستودع INT NOT NULL PRIMARY KEY,
اسم_المستودع VARCHAR(50) NOT NULL DEFAULT ''
);

DROP TABLE IF EXISTS material;

CREATE TABLE material(
الرقم_الفني INT NOT NULL PRIMARY KEY IDENTITY(1,1),
اسم_المادة VARCHAR(100) NOT NULL,
تواجد_المادة VARCHAR(50),
الوحدة VARCHAR(20) NOT NULL,
كمية INT NOT NULL DEFAULT 0,
سعر FLOAT NOT NULL DEFAULT 0,
رمز_الطراز VARCHAR(30),
المجموعة INT FOREIGN KEY REFERENCES material_group(رقم_المجموعة) DEFAULT 0,
الصانع INT FOREIGN KEY REFERENCES producer(رقم_الصانع) DEFAULT 0,
المستودع INT FOREIGN KEY REFERENCES WareHouse(رقم_المستودع) DEFAULT 0
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

DROP TABLE IF EXISTS material_cost;

CREATE TABLE material_cost(
المادة INT FOREIGN KEY REFERENCES material(الرقم_الفني),
سعر_الشراء INT NOT NULL,
كمية INT NOT NULL DEFAULT 0,
التاريخ DATETIME
);

ALTER TABLE material_cost ADD رقم_فاتورة_الشراء INT;

DROP TABLE IF EXISTS customer;

CREATE TABLE customer(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(0,1),
اسم_الزبون VARCHAR(50) NOT NULL UNIQUE,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
عنوان_الزبون VARCHAR(100),
هاتف VARCHAR(20),
الموبايل VARCHAR(20),
البريد_الالكتروني VARCHAR(50),
الموقع_الالكتروني VARCHAR(50),
تاريخ DATETIME,
وصف_الزبون VARCHAR(MAX),
صورة VARCHAR(100)
);

INSERT INTO [Computer].[dbo].[customer]
           ([اسم_الزبون]
           ,[الرصيد]
           ,[الرصيد_كتابة]
           ,[عنوان_الزبون]
           ,[هاتف]
           ,[الموبايل]
           ,[البريد_الالكتروني]
           ,[الموقع_الالكتروني]
           ,[تاريخ]
           ,[وصف_الزبون]
           ,[صورة])
     VALUES
           ('غير معروف'
           ,0
           ,'صفر'
           ,''
           ,''
           ,''
           ,''
           ,''
           ,GETDATE()
           ,''
           ,'');

DROP TABLE IF EXISTS customer_debit;

CREATE TABLE customer_debit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT 'توريد بضاعة لعميل',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
customer_id INT FOREIGN KEY REFERENCES customer(الرقم)
);

DROP TABLE IF EXISTS customer_credit;

CREATE TABLE customer_credit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT 'تسديد قيمة البضاعة',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
customer_id INT FOREIGN KEY REFERENCES customer(الرقم)
);

CREATE TABLE customer_ReveiveTime(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
customer_id INT FOREIGN KEY REFERENCES customer(الرقم)
);

ALTER TABLE customer_ReveiveTime ADD تم_الدفع VARCHAR(10) DEFAULT 'false';

DROP TABLE IF EXISTS supplier;

CREATE TABLE supplier(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(0,1),
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
صورة VARCHAR(100)
);

INSERT INTO [Computer].[dbo].[supplier]
           ([اسم_المورد]
           ,[الرصيد]
           ,[الرصيد_كتابة]
           ,[عنوان_المورد]
           ,[هاتف]
           ,[الموبايل]
           ,[البريد_الالكتروني]
           ,[الموقع_الالكتروني]
           ,[تاريخ]
           ,[وصف_المورد]
           ,[صورة])
     VALUES
           ('غير معروف'
           ,0
           ,'صفر'
           ,''
           ,''
           ,''
           ,''
           ,''
           ,GETDATE()
           ,''
           ,'');

DROP TABLE IF EXISTS supplier_debit;

CREATE TABLE supplier_debit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT 'توريد مبلغ للمورد',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
Supplier_id INT FOREIGN KEY REFERENCES supplier(الرقم)
);

DROP TABLE IF EXISTS supplier_credit;

CREATE TABLE supplier_credit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT 'استيراد بضاعة من المورد',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
Supplier_id INT FOREIGN KEY REFERENCES supplier(الرقم)
);

CREATE TABLE supplier_PayTime(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
Supplier_id INT FOREIGN KEY REFERENCES supplier(الرقم)
);

ALTER TABLE supplier_PayTime ADD تم_الدفع VARCHAR(10) DEFAULT 'false';

DROP TABLE IF EXISTS material_debit;

CREATE TABLE material_debit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
تاريخ DATETIME NOT NULL,
الرصيد FLOAT NOT NULL,
من VARCHAR(100),
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
رقم_فاتورة_المصدر INT,
تاريخ_فاتورة_المصدر DATETIME,
المصدر VARCHAR(40),
المستودع VARCHAR(10),
المورد INT NOT NULL FOREIGN KEY REFERENCES supplier(الرقم)
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

DROP TABLE IF EXISTS material_debit_list;

CREATE TABLE material_debit_list(
رقم_المادة INT NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_التقرير INT NOT NULL FOREIGN KEY REFERENCES material_debit(الرقم),
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
رقم_التقرير INT NOT NULL FOREIGN KEY REFERENCES material_debit(الرقم),
الفائدة INT NOT NULL,
نسبة_الفائدة INT NOT NULL,
الدفع_كل INT NOT NULL,
عدد_الأقساط INT NOT NULL
);

ALTER TABLE material_debit_penfit_payment ADD العربون INT DEFAULT 0;

DROP TABLE IF EXISTS material_debit_return;

CREATE TABLE material_debit_return(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
تاريخ DATETIME NOT NULL,
الرصيد FLOAT NOT NULL,
من VARCHAR(100),
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
رقم_فاتورة_المصدر INT,
تاريخ_فاتورة_المصدر DATETIME,
المصدر VARCHAR(40),
المستودع VARCHAR(10),
العميل INT NOT NULL FOREIGN KEY REFERENCES customer(الرقم)
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

DROP TABLE IF EXISTS material_debit_list_return;

CREATE TABLE material_debit_list_return(
رقم_المادة INT NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_التقرير INT NOT NULL FOREIGN KEY REFERENCES material_debit_return(الرقم),
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
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
تاريخ_البيع DATETIME NOT NULL,
تاريخ_التسليم DATETIME NOT NULL,
الرصيد FLOAT NOT NULL,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100),
طريقة_الدفع VARCHAR(20),
المستودع VARCHAR(10),
العميل INT NOT NULL FOREIGN KEY REFERENCES customer(الرقم)
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

DROP TABLE IF EXISTS material_credit_list;

CREATE TABLE material_credit_list(
رقم_المادة INT NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_التقرير INT NOT NULL FOREIGN KEY REFERENCES material_credit(الرقم),
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
رقم_التقرير INT NOT NULL FOREIGN KEY REFERENCES material_credit(الرقم),
الفائدة INT NOT NULL,
نسبة_الفائدة INT NOT NULL,
الدفع_كل INT NOT NULL,
عدد_الأقساط INT NOT NULL
);

ALTER TABLE material_credit_penfit_payment ADD العربون INT DEFAULT 0;

DROP TABLE IF EXISTS material_credit_return;

CREATE TABLE material_credit_return(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
تاريخ_البيع DATETIME NOT NULL,
تاريخ_التسليم DATETIME NOT NULL,
الرصيد FLOAT NOT NULL,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100),
طريقة_الدفع VARCHAR(20),
المستودع VARCHAR(10),
المورد INT NOT NULL FOREIGN KEY REFERENCES supplier(الرقم)
);

ALTER TABLE material_credit_return ADD حذفة VARCHAR(5) DEFAULT '';
ALTER TABLE material_credit_return ADD بالة VARCHAR(5) DEFAULT '';
ALTER TABLE material_credit_return ADD نوع_العملية VARCHAR(30) DEFAULT 'بيع';
ALTER TABLE material_credit_return ADD حسام_ممنوح FLOAT DEFAULT 0;
ALTER TABLE material_credit_return ADD مصاريف_مضافة FLOAT DEFAULT 0;
ALTER TABLE material_credit_return ADD مصاريف_على_حساب VARCHAR(20);
ALTER TABLE material_credit_return ADD مرحل VARCHAR(5);
ALTER TABLE material_credit_return ADD اسم_الحساب VARCHAR(30);

DROP TABLE IF EXISTS material_credit_list_return;

CREATE TABLE material_credit_list_return(
رقم_المادة INT NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_التقرير INT NOT NULL FOREIGN KEY REFERENCES material_credit_return(الرقم),
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
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
اسم_الصندوق VARCHAR(20) NOT NULL,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME NOT NULL
);

INSERT INTO [Computer].[dbo].[box]
           ([اسم_الصندوق]
           ,[الرصيد]
           ,[الرصيد_كتابة]
           ,[تاريخ])
     VALUES
           ('صندوق اليومية'
           ,0
           ,'صفر'
           ,CURRENT_TIMESTAMP);

DROP TABLE IF EXISTS box_debit;

CREATE TABLE box_debit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT 'القرض نقدا',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
box_id INT FOREIGN KEY REFERENCES box(الرقم)
);

DROP TABLE IF EXISTS box_credit;

CREATE TABLE box_credit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT 'تسديد نقدا',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
box_id INT FOREIGN KEY REFERENCES box(الرقم)
);

DROP TABLE IF EXISTS bank_details;

CREATE TABLE bank_details(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
اسم_البنك VARCHAR(50) NOT NULL,
عنوان_البنك VARCHAR(100),
هاتف VARCHAR(20),
الموبايل VARCHAR(20),
البريد_الالكتروني VARCHAR(50),
الموقع_الالكتروني VARCHAR(50)
);

ALTER TABLE bank_details ADD تعليق VARCHAR(100);

DROP TABLE IF EXISTS bank_account;

CREATE TABLE bank_account(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
اسم_الحساب VARCHAR(50) NOT NULL,
رقم_الحساب VARCHAR(20) NOT NULL,
نوع_الحساب VARCHAR(30) NOT NULL,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME NOT NULL,
bank_id INT FOREIGN KEY REFERENCES bank_details(الرقم)
);

ALTER TABLE bank_account ADD تعليق VARCHAR(100);

DROP TABLE IF EXISTS bank_debit;

CREATE TABLE bank_debit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT ' ',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
bank_id INT FOREIGN KEY REFERENCES bank_account(الرقم)
);

DROP TABLE IF EXISTS bank_credit;

CREATE TABLE bank_credit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT ' ',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
bank_id INT FOREIGN KEY REFERENCES bank_account(الرقم)
);

CREATE TABLE bonds(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT ' ',
الى VARCHAR(100) DEFAULT ' ',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME
);

ALTER TABLE bonds ADD مرحل VARCHAR(5);

DROP TABLE IF EXISTS asset;

CREATE TABLE asset(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
اسم_الأصل VARCHAR(20) NOT NULL,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME NOT NULL
);

ALTER TABLE asset ADD نوع_الأصل VARCHAR(100);
ALTER TABLE asset ADD نسبة_الأهتلاك INT DEFAULT 0;
ALTER TABLE asset ADD قيمة_النفاية INT DEFAULT 0;
ALTER TABLE asset ADD مجموع_الأهتلاك INT DEFAULT 0;

DROP TABLE IF EXISTS asset_debit;

CREATE TABLE asset_debit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
asset_id INT FOREIGN KEY REFERENCES asset(الرقم)
);

DROP TABLE IF EXISTS asset_credit;

CREATE TABLE asset_credit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
asset_id INT FOREIGN KEY REFERENCES asset(الرقم)
);

DROP TABLE IF EXISTS paper_receive;

CREATE TABLE paper_receive(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME,
تاريخ_الاستحقاق DATETIME,
الساحب VARCHAR(50),
المسحوب_عليه VARCHAR(50)
);

DROP TABLE IF EXISTS paper_receive_debit;

CREATE TABLE paper_receive_debit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
paper_receive_id INT FOREIGN KEY REFERENCES paper_receive(الرقم)
);

DROP TABLE IF EXISTS paper_receive_credit;

CREATE TABLE paper_receive_credit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
paper_receive_id INT FOREIGN KEY REFERENCES paper_receive(الرقم)
);

DROP TABLE IF EXISTS paper_pay;

CREATE TABLE paper_pay(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME,
تاريخ_الاستحقاق DATETIME,
الساحب VARCHAR(50),
المسحوب_عليه VARCHAR(50)
);

DROP TABLE IF EXISTS paper_pay_debit;

CREATE TABLE paper_pay_debit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
paper_receive_id INT FOREIGN KEY REFERENCES paper_pay(الرقم)
);

DROP TABLE IF EXISTS paper_pay_credit;

CREATE TABLE paper_pay_credit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
paper_receive_id INT FOREIGN KEY REFERENCES paper_pay(الرقم)
);

CREATE TABLE liability(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الالتزام VARCHAR(20) NOT NULL,
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
تاريخ DATETIME NOT NULL
);

ALTER TABLE liability ADD نوع_الالتزام VARCHAR(100);
ALTER TABLE liability ADD نسبة_الفائدة INT DEFAULT 0;

DROP TABLE IF EXISTS liability_debit;

CREATE TABLE liability_debit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
من VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
liability_id INT FOREIGN KEY REFERENCES liability(الرقم)
);

DROP TABLE IF EXISTS liability_credit;

CREATE TABLE liability_credit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
الرصيد FLOAT NOT NULL DEFAULT 0,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100) DEFAULT '',
ملاحظات VARCHAR(MAX),
تاريخ DATETIME,
liability_id INT FOREIGN KEY REFERENCES liability(الرقم)
);

DROP TABLE IF EXISTS error;

CREATE TABLE error(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
class VARCHAR(50),
error_ms VARCHAR(MAX),
error_row INT
);

DROP TABLE IF EXISTS material_maker;

CREATE TABLE material_maker(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
اسم_المادة VARCHAR(100) NOT NULL,
الوحدة VARCHAR(20) NOT NULL,
كمية INT NOT NULL DEFAULT 0,
الكلفة FLOAT NOT NULL DEFAULT 0,
سعر_البيع FLOAT NOT NULL DEFAULT 0,
المجموعة INT FOREIGN KEY REFERENCES material_group(رقم_المجموعة) DEFAULT 0,
المستودع INT FOREIGN KEY REFERENCES WareHouse(رقم_المستودع) DEFAULT 0
);

ALTER TABLE material_maker ADD كلف INT;
ALTER TABLE material_maker ADD المستودع INT;
ALTER TABLE material_maker ADD المستودع INT;

DROP TABLE IF EXISTS material_maker_list;

CREATE TABLE material_maker_list(
رقم_المادة INT NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_المصنع INT NOT NULL FOREIGN KEY REFERENCES material_maker(الرقم),
اسم_المادة VARCHAR(100) NOT NULL,
الوحدة VARCHAR(20) NOT NULL,
كمية INT NOT NULL DEFAULT 0,
سعر_الشراء FLOAT NOT NULL DEFAULT 0,
نسبة_الهدر FLOAT NOT NULL DEFAULT 0,
كلفة_المادة FLOAT NOT NULL DEFAULT 0,
ملاحظات VARCHAR(100) NOT NULL
);

DROP TABLE IF EXISTS materialMaker_credit;

CREATE TABLE materialMaker_credit(
الرقم INT NOT NULL PRIMARY KEY IDENTITY(1,1),
تاريخ_بداية_التصنيع DATETIME NOT NULL,
تاريخ_نهاية_التصنيع DATETIME NOT NULL,
الكلفة FLOAT NOT NULL,
الرصيد_كتابة VARCHAR(150) NOT NULL DEFAULT 'صفر',
الى VARCHAR(100),
المستودع VARCHAR(10)
);

ALTER TABLE materialMaker_credit ADD هدر FLOAT DEFAULT 0;
ALTER TABLE materialMaker_credit ADD مصاريف_مضافة FLOAT DEFAULT 0;
ALTER TABLE materialMaker_credit ADD كمية_الانتاج FLOAT DEFAULT 0;

DROP TABLE IF EXISTS materialMaker_credit_list;

CREATE TABLE materialMaker_credit_list(
رقم_المادة INT NOT NULL FOREIGN KEY REFERENCES material(الرقم_الفني),
رقم_التقرير INT NOT NULL FOREIGN KEY REFERENCES materialMaker_credit(الرقم),
اسم_المادة VARCHAR(100) NOT NULL,
الوحدة VARCHAR(20) NOT NULL,
كمية INT NOT NULL,
السعر FLOAT NOT NULL,
السعر_الجمالي FLOAT NOT NULL,
ملاحظات VARCHAR(50)
);

ALTER TABLE materialMaker_credit_list ADD المستودع INT;
ALTER TABLE materialMaker_credit_list ADD هدر FLOAT DEFAULT 0;
