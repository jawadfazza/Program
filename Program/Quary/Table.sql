create table admin_(
id int not null primary key identity(1,1) ,
username varchar(50) not null unique ,
password varchar(50) not null ,
user_type varchar(10) 
)

Create Table Country(
id int not null primary key identity(1,1) ,
name varchar(50) not null unique 
)

drop table user_loge

create table user_loge(
id int not null primary key identity(1,1) ,
username varchar(50) not null unique ,
password varchar(50) not null ,
user_type varchar(10) 
)
alter table user_loge add enable_delete varchar(6) default 'No'
alter table user_loge add remamber varchar(6) default 'No'



drop table user_task

create table user_task(
id int not null primary key identity(1,1) ,
opreation varchar(100) not null  ,
active_opreation varchar(5),
user_id_ int not null foreign key  references user_loge(id)
)


drop table task

create table task(
id int not null primary key identity(1,1) ,
opreation varchar(100) not null 
)


drop table user_loge_date
create table user_loge_date(
id int  not null primary key identity(1,1) , 
loge_date_in datetime not null,
user_id_ int not null foreign key  references user_loge(id)
)

drop table company

Create table company(
id int  not null primary key identity(1,1) , 
name varchar(30) not null,
street  varchar(MAX) not null,
city varchar(150) not null,
country varchar(30) not null,
phone varchar(30) not null,
email varchar(50) not null,
web_site varchar(60) not null,
logo image
)
alter table company add active varchar(6) default 'false'
alter table company add block_Date datetime 

drop table material_group

create table material_group(
ÑŞã_ÇáãÌãæÚÉ int not null primary key ,
ÇÓã_ÇáãÌãæÚÉ varchar(100) not null default ''
)
 
drop table producer 

create table producer(
ÑŞã_ÇáÕÇäÚ int not null primary key ,
ÇÓã_ÇáÕÇäÚ varchar(60) not null default '',
ÑãÒ_ÇáäæÚ varchar(50) not null default '',
)

drop table WareHouse

create table WareHouse(
ÑŞã_ÇáãÓÊæÏÚ int not null primary key ,
ÇÓã_ÇáãÓÊæÏÚ  varchar(50) not null default ''
)

drop table material

create table material(
ÇáÑŞã_Çáİäí int not null primary key identity(1,1),
ÇÓã_ÇáãÇÏÉ varchar(100) not null ,
ÊæÇÌÏ_ÇáãÇÏÉ varchar(50),
ÇáæÍÏÉ varchar(20) not null ,
ßãíÉ int not null default 0,
ÓÚÑ float not null default 0 ,
ÑãÒ_ÇáØÑÇÒ varchar(30),
ÇáãÌãæÚÉ int  foreign key references   material_group(ÑŞã_ÇáãÌãæÚÉ) default 0 ,
ÇáÕÇäÚ int  foreign key references   producer(ÑŞã_ÇáÕÇäÚ) default 0,
ÇáãÓÊæÏÚ int  foreign key references WareHouse(ÑŞã_ÇáãÓÊæÏÚ) default 0
)
--alter table material add ÇáÃáíÉ int foreign key references machine_type(ÊÓáÓá) default 0
alter table material add ÈÇáÉ varchar(6) default 'false'
alter table material add æÕİ_ÇáãÇÏÉ  varchar(max)
alter table material add ÕæÑÉ  varchar(100)
alter table material add İÑŞ_ÇáÓÚÑ  int default 0
alter table material add İÑŞ_ÇáßãíÉ  int default 0
alter table material add ÓÚÑ_ÇáÔÑÇÁ  int default 0
alter table material add ÓÚÑ_ÇáÈíÚ  int default 0
alter table material add ßæÏ_ÇáãÇÏÉ  varchar(30) default ''
alter table material add ØÑíŞÉ_ÍÓÇÈ_ÇáßáİÉ  varchar(10)


drop table material_cost

create table material_cost( 
ÇáãÇÏÉ int  foreign key references material(ÇáÑŞã_Çáİäí) ,
ÓÚÑ_ÇáÔÑÇÁ int not null ,
ßãíÉ int not null default 0,
ÇáÊÇÑíÎ datetime
)
alter table material_cost add ÑŞã_İÇÊæÑÉ_ÇáÔÑÇÁ  int


drop table customer

create table customer(
ÇáÑŞã int not null primary key identity(0,1),
ÇÓã_ÇáÑÈæä varchar(50) not null unique,
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ÚäæÇä_ÇáÑÈæä varchar(100),
åÇÊİ varchar(20),
ÇáãæÈÇíá varchar(20),
ÇáÈÑíÏ_ÇáÇáßÊÑæäí varchar(50),
ÇáãæŞÚ_ÇáÇáßÊÑæäí varchar(50),
ÊÇÑíÎ datetime,
æÕİ_ÇáÑÈæä varchar(max),
ÕæÑÉ varchar(100)
)

INSERT INTO [Computer].[dbo].[customer]
           ([ÇÓã_ÇáÑÈæä]
           ,[ÇáÑÕíÏ]
           ,[ÇáÑÕíÏ_ßÊÇÈÉ]
           ,[ÚäæÇä_ÇáÑÈæä]
           ,[åÇÊİ]
           ,[ÇáãæÈÇíá]
           ,[ÇáÈÑíÏ_ÇáÇáßÊÑæäí]
           ,[ÇáãæŞÚ_ÇáÇáßÊÑæäí]
           ,[ÊÇÑíÎ]
           ,[æÕİ_ÇáÑÈæä]
           ,[ÕæÑÉ])
     VALUES
           ('ÛíÑ ãÚÑæİ'
           ,0
           ,'ÕİÑ'
           ,''
           ,''
           ,''
           ,''
           ,''
           ,GETDATE ( )
           ,''
           ,'')


drop table customer_debit

--ãÏíä
create table customer_debit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ãä varchar(100) default 'ÊæÑíÏ ÈÖÇÚÉ áÚãíá ',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
customer_id int  foreign key references   customer(ÇáÑŞã)
)

drop table customer_credit

--ÏÇÆä
create table customer_credit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
Åáì varchar(100) default ' ÊÓÏíÏ ŞíãÉ ÇáÈÖÇÚÉ ',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
customer_id int  foreign key references   customer(ÇáÑŞã)
)

create table customer_ReveiveTime(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
customer_id int  foreign key references   customer(ÇáÑŞã)
)
alter table customer_ReveiveTime add Êã_ÇáÏİÚ varchar(10) default 'false' 


drop table supplier

create table supplier(
ÇáÑŞã int not null primary key identity(0,1),
ÇÓã_ÇáãæÑÏ varchar(50) not null unique,
ÇáÑÕíÏ float not null default 0 ,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ' ,
ÚäæÇä_ÇáãæÑÏ varchar(100),
åÇÊİ varchar(20),
ÇáãæÈÇíá varchar(20),
ÇáÈÑíÏ_ÇáÇáßÊÑæäí varchar(50),
ÇáãæŞÚ_ÇáÇáßÊÑæäí varchar(50),
ÊÇÑíÎ datetime ,
æÕİ_ÇáãæÑÏ varchar(max),
ÕæÑÉ varchar(100)
)

INSERT INTO [Computer].[dbo].[supplier]
           ([ÇÓã_ÇáãæÑÏ]
           ,[ÇáÑÕíÏ]
           ,[ÇáÑÕíÏ_ßÊÇÈÉ]
           ,[ÚäæÇä_ÇáãæÑÏ]
           ,[åÇÊİ]
           ,[ÇáãæÈÇíá]
           ,[ÇáÈÑíÏ_ÇáÇáßÊÑæäí]
           ,[ÇáãæŞÚ_ÇáÇáßÊÑæäí]
           ,[ÊÇÑíÎ]
           ,[æÕİ_ÇáãæÑÏ]
           ,[ÕæÑÉ])
     VALUES
           ('ÛíÑ ãÚÑæİ'
           ,0
           ,'ÕİÑ'
           ,''
           ,''
           ,''
           ,''
           ,''
           ,GETDATE ( )
           ,''
           ,'')

drop table supplier_debit

--ãÏíä
create table supplier_debit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ãä varchar(100) default 'ÊÓÏíÏ ãÈáÛ ááãæÑÏ ',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
Supplier_id int  foreign key references   supplier(ÇáÑŞã)
)

drop table supplier_credit

--ÏÇÆä
create table supplier_credit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
Åáì varchar(100) default 'ÇÓÊíÑÇÏ ÈÖÇÚÉ ãä ÇáãæÑÏ ',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
Supplier_id int  foreign key references   supplier(ÇáÑŞã)
)

create table supplier_PayTime(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
Supplier_id int  foreign key references   supplier(ÇáÑŞã)
)
alter table supplier_PayTime add Êã_ÇáÏİÚ varchar(10) default 'false'



Drop table material_debit
--ãÏíä
create table material_debit(
ÇáÑŞã int not null primary key identity(1,1) ,
ÊÇÑíÎ datetime not null ,
ÇáÑÕíÏ float not null,
ãä varchar(100) ,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ÑŞã_İÇÊæÑÉ_ÇáãÕÏÑ int  ,
ÊÇÑíÎ_İÇÊæÑÉ_ÇáãÕÏÑ datetime  ,
ÇáãÕÏÑ varchar(40),
ÇáãÓÊæÏÚ varchar(10) ,
ÇáãæÑÏ int not null foreign key references supplier(ÇáÑŞã),
)
alter table material_debit add ÍĞİÉ varchar(5) default ''
alter table material_debit add äæÚ_ÇáÚãáíÉ varchar(10) default 'ÔÑÇÁ' 
alter table material_debit add ÍÓã_ãßÊÓÈ float default 0 
alter table material_debit add ãÕÇÑíİ_ãÖÇİÉ float default 0 
alter table material_debit add ãÕÇÑíİ_Úáì_ÍÓÇÈ varchar(20)  
alter table material_debit add ãÑÍá varchar(5)   --true or false Êã ÊÑÍíá ÇáŞíæÏ
alter table material_debit add ØÑíŞÉ_ÇáÏİÚ varchar(10)  
alter table material_debit add ÇÓã_ÇáÍÓÇÈ varchar(30) 
alter table material_debit add ÓäÏ_ÇáÏİÚ int default 0






/**/
drop table material_debit_list
--ãæÇÏ ãÏíä
create table material_debit_list(
ÑŞã_ÇáãÇÏÉ int not null foreign key references material(ÇáÑŞã_Çáİäí),
ÑŞã_ÇáÊŞÑíÑ int not null foreign key references material_debit(ÇáÑŞã),
ÇÓã_ÇáãÇÏÉ varchar(100) not null ,
ÇáæÍÏÉ varchar(20) not null ,
ÇáßãíÉ int not null ,
ÇáÓÚÑ float not null ,	
ÇáÓÚÑ_ÇáÌãÇáí float not null ,
ãáÇÍÙÇÊ varchar(50) 
)
alter table material_debit_list add ÇáãÓÊæÏÚ int 
alter table material_debit_list add ÇáßãíÉ_ßÊÇÈÉ varchar(50)
alter table material_debit_list add ÍĞİÉ varchar(5) default ''
alter table material_debit_list add ÍÓã_ãßÊÓÈ float default 0 

drop table material_debit_penfit_payment
--ãæÇÏ ÏÇÆä
create table material_debit_penfit_payment(
ÑŞã_ÇáÊŞÑíÑ int not null foreign key references material_debit(ÇáÑŞã),
ÇáİÇÆÏÉ int not null,
äÓÈÉ_ÇáİÇÆÏÉ int not null,
ÇáÏİÚ_ßá int not null,
ÚÏÏ_ÇáÃŞÓÇØ int not null)
alter table material_debit_penfit_payment add ÇáÑÚÈæä int default 0


Drop table material_debit_return
--ãÏíä
create table material_debit_return(
ÇáÑŞã int not null primary key identity(1,1) ,
ÊÇÑíÎ datetime not null ,
ÇáÑÕíÏ float not null,
ãä varchar(100) ,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ÑŞã_İÇÊæÑÉ_ÇáãÕÏÑ int  ,
ÊÇÑíÎ_İÇÊæÑÉ_ÇáãÕÏÑ datetime  ,
ÇáãÕÏÑ varchar(40),
ÇáãÓÊæÏÚ varchar(10) ,
ÇáÚãíá int not null foreign key references customer(ÇáÑŞã),
)
alter table material_debit_return add ÍĞİÉ varchar(5) default ''
alter table material_debit_return add äæÚ_ÇáÚãáíÉ varchar(10) default 'ÔÑÇÁ' 
alter table material_debit_return add ÍÓã_ãßÊÓÈ float default 0 
alter table material_debit_return add ãÕÇÑíİ_ãÖÇİÉ float default 0 
alter table material_debit_return add ãÕÇÑíİ_Úáì_ÍÓÇÈ varchar(20)  
alter table material_debit_return add ãÑÍá varchar(5)   --true or false Êã ÊÑÍíá ÇáŞíæÏ
alter table material_debit_return add ØÑíŞÉ_ÇáÏİÚ varchar(10)  
alter table material_debit_return add ÇÓã_ÇáÍÓÇÈ varchar(30) 
alter table material_debit_return add ÇáßáİÉ float 


-- ÇãÇ ÔÑÇÁ Ãæ ÑÏø ÈÖÇÚÉ 


/**/
drop table material_debit_list_return
--ãæÇÏ ãÏíä
create table material_debit_list_return(
ÑŞã_ÇáãÇÏÉ int not null foreign key references material(ÇáÑŞã_Çáİäí),
ÑŞã_ÇáÊŞÑíÑ int not null foreign key references material_debit_return(ÇáÑŞã),
ÇÓã_ÇáãÇÏÉ varchar(100) not null ,
ÇáæÍÏÉ varchar(20) not null ,
ÇáßãíÉ int not null ,
ÇáÓÚÑ float not null ,	
ÇáÓÚÑ_ÇáÌãÇáí float not null ,
ãáÇÍÙÇÊ varchar(50) 
)
alter table material_debit_list_return add ÇáãÓÊæÏÚ int 
alter table material_debit_list_return add ÇáßãíÉ_ßÊÇÈÉ varchar(50)
alter table material_debit_list_return add ÍĞİÉ varchar(5) default ''
alter table material_debit_list_return add ÍÓã_ãßÊÓÈ float default 0 
alter table material_debit_list_return add ÓÚÑ_ÇáÔÑÇÁ int 
alter table material_debit_list_return add ÇáßáİÉ float 




drop table material_credit
--ÏÇÆä
create table  material_credit(
ÇáÑŞã int not null primary key identity(1,1) ,
ÊÇÑíÎ_ÇáÈíÚ datetime not null ,
ÊÇÑíÎ_ÇáÊÓáíã datetime not null ,
ÇáÑÕíÏ float not null,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
Åáì varchar(100) ,
ØÑíŞÉ_ÇáÏİÚ varchar(20),--äŞÏÇ Çæ áÇÌá
ÇáãÓÊæÏÚ varchar(10),
ÇáÚãíá int not null foreign key references customer(ÇáÑŞã)
)
alter table material_credit add ÍĞİÉ varchar(5) default ''
alter table material_credit add ÈÇáÉ varchar(5) default ''
alter table material_credit add äæÚ_ÇáÚãáíÉ varchar(30) default 'ÈíÚ' 
alter table material_credit add ÍÓã_ããäæÍ float default 0 
alter table material_credit add ãÕÇÑíİ_ãÖÇİÉ float default 0 
alter table material_credit add ãÕÇÑíİ_Úáì_ÍÓÇÈ varchar(20)  
alter table material_credit add ãÑÍá varchar(5)   --true or false Êã ÊÑÍíá ÇáŞíæÏ
alter table material_credit add ÇÓã_ÇáÍÓÇÈ varchar(30) 
alter table material_credit add ÓäÏ_ÇáŞÈÖ int default 0
alter table material_credit add ÇáİÇÆÏÉ int default 0
alter table material_credit add ÇáÏİÚ_ßá int default 0
alter table material_credit add ÚÏÏ_ÇáÃŞÓÇØ int default 0
alter table material_credit add ÇáßáİÉ float 


-- ÇãÇ ÈíÚ Ãæ ÑÏø ãÔÊÑíÇÊ 



drop table material_credit_list
--ãæÇÏ ÏÇÆä
create table material_credit_list(
ÑŞã_ÇáãÇÏÉ int not null foreign key references material(ÇáÑŞã_Çáİäí),
ÑŞã_ÇáÊŞÑíÑ int not null foreign key references material_credit(ÇáÑŞã),
ÇÓã_ÇáãÇÏÉ varchar(100) not null ,
ÇáæÍÏÉ varchar(20) not null ,
ÇáßãíÉ int not null ,
ÇáÓÚÑ float not null ,	
ÇáÓÚÑ_ÇáÌãÇáí float not null ,
ãáÇÍÙÇÊ varchar(50) 
)
alter table material_credit_list add ÇáãÓÊæÏÚ int 
alter table material_credit_list add ÇáßãíÉ_ßÊÇÈÉ varchar(50)
alter table material_credit_list add ÍĞİÉ varchar(5) default ''
alter table material_credit_list add ÍÓã_ããäæÍ float default 0 
alter table material_credit_list add ÓÚÑ_ÇáÔÑÇÁ int 
alter table material_credit_list add ÇáßáİÉ float 


drop table material_credit_penfit_payment
--ãæÇÏ ÏÇÆä
create table material_credit_penfit_payment(
ÑŞã_ÇáÊŞÑíÑ int not null foreign key references material_credit(ÇáÑŞã),
ÇáİÇÆÏÉ int not null,
äÓÈÉ_ÇáİÇÆÏÉ int not null,
ÇáÏİÚ_ßá int not null,
ÚÏÏ_ÇáÃŞÓÇØ int not null)
alter table material_credit_penfit_payment add ÇáÑÚÈæä int default 0



drop table material_credit_return
--ÏÇÆä
create table  material_credit_return(
ÇáÑŞã int not null primary key identity(1,1) ,
ÊÇÑíÎ_ÇáÈíÚ datetime not null ,
ÊÇÑíÎ_ÇáÊÓáíã datetime not null ,
ÇáÑÕíÏ float not null,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
Åáì varchar(100) ,
ØÑíŞÉ_ÇáÏİÚ varchar(20),--äŞÏÇ Çæ áÇÌá
ÇáãÓÊæÏÚ varchar(10),
ÇáãæÑÏ int not null foreign key references supplier(ÇáÑŞã)
)
alter table material_credit_return add ÍĞİÉ varchar(5) default ''
alter table material_credit_return add ÈÇáÉ varchar(5) default ''
alter table material_credit_return add äæÚ_ÇáÚãáíÉ varchar(30) default 'ÈíÚ' 
alter table material_credit_return add ÍÓã_ããäæÍ float default 0 
alter table material_credit_return add ãÕÇÑíİ_ãÖÇİÉ float default 0 
alter table material_credit_return add ãÕÇÑíİ_Úáì_ÍÓÇÈ varchar(20)  
alter table material_credit_return add ãÑÍá varchar(5)   --true or false Êã ÊÑÍíá ÇáŞíæÏ
alter table material_credit_return add ÇÓã_ÇáÍÓÇÈ varchar(30) 

-- ÇãÇ ÈíÚ Ãæ ÑÏø ãÔÊÑíÇÊ 

drop table material_credit_list_return
--ãæÇÏ ÏÇÆä
create table material_credit_list_return(
ÑŞã_ÇáãÇÏÉ int not null foreign key references material(ÇáÑŞã_Çáİäí),
ÑŞã_ÇáÊŞÑíÑ int not null foreign key references material_credit_return(ÇáÑŞã),
ÇÓã_ÇáãÇÏÉ varchar(100) not null ,
ÇáæÍÏÉ varchar(20) not null ,
ÇáßãíÉ int not null ,
ÇáÓÚÑ float not null ,	
ÇáÓÚÑ_ÇáÌãÇáí float not null ,
ãáÇÍÙÇÊ varchar(50) 
)
alter table material_credit_list_return add ÇáãÓÊæÏÚ int 
alter table material_credit_list_return add ÇáßãíÉ_ßÊÇÈÉ varchar(50)
alter table material_credit_list_return add ÍĞİÉ varchar(5) default ''
alter table material_credit_list_return add ÍÓã_ããäæÍ float default 0 

/**/
drop table box
--ÑÕíÏ ãÏíä
create table box(
ÇáÑŞã int not null primary key identity(1,1),
ÇÓã_ÇáÕäÏæŞ varchar(20)not null,
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ÊÇÑíÎ datetime not null,
)

INSERT INTO [Computer].[dbo].[box]
           ([ÇÓã_ÇáÕäÏæŞ]
           ,[ÇáÑÕíÏ]
           ,[ÇáÑÕíÏ_ßÊÇÈÉ]
           ,[ÊÇÑíÎ])
     VALUES
           ('ÕäÏæŞ ÇáíæãíÉ'
           ,0
           ,'ÕİÑ'
           ,CURRENT_TIMESTAMP)
GO

drop table box_debit

--ãÏíä
create table box_debit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ãä varchar(100) default ' ÇáŞÈÖ äŞÏÇ',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
box_id int  foreign key references   box(ÇáÑŞã),
)

drop table box_credit

--ÏÇÆä
create table box_credit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
Åáì varchar(100) default ' ÊÓÏíÏ äŞÏÇ ',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
box_id int  foreign key references   box(ÇáÑŞã)
)


drop table bank_details

create table bank_details(
ÇáÑŞã int not null primary key identity(1,1),
ÇÓã_ÇáÈäß  varchar(50) not null ,
ÚäæÇä_ÇáÈäß varchar(100),
åÇÊİ varchar(20),
ÇáãæÈÇíá varchar(20),
ÇáÈÑíÏ_ÇáÇáßÊÑæäí varchar(50),
ÇáãæŞÚ_ÇáÇáßÊÑæäí varchar(50)
)
alter table bank_details add ÊÚáíŞ varchar(100) 


drop table bank_account

create table bank_account(
ÇáÑŞã int not null primary key identity(1,1),
ÇÓã_ÇáÍÓÇÈ varchar(50) not null ,
ÑŞã_ÇáÍÓÇÈ varchar(20) not null,
äæÚ_ÇáÍÓÇÈ varchar(30)not null,
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ÊÇÑíÎ datetime not null,
bank_id int  foreign key references   bank_details(ÇáÑŞã)
)
alter table bank_account add ÊÚáíŞ varchar(100) 


drop table bank_debit

--ãÏíä
create table bank_debit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ãä varchar(100) default ' ',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
bank_id int  foreign key references   bank_account(ÇáÑŞã),
)

drop table bank_credit

--ÏÇÆä
create table bank_credit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
Åáì varchar(100) default ' ',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
bank_id int  foreign key references   bank_account(ÇáÑŞã)
)


create table bonds(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ãä varchar(100) default ' ',
Åáì varchar(100) default ' ',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime
)
alter table bonds add   ãÑÍá varchar(5)

drop table asset
--ÑÕíÏ ãÏíä
create table asset(
ÇáÑŞã int not null primary key identity(1,1),
ÇÓã_ÇáÃÕá varchar(20)not null,
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ÊÇÑíÎ datetime not null,
)
alter table asset add äæÚ_ÇáÃÕá  varchar(100)
alter table asset add äÓÈÉ_ÇáÃåÊáÇß  int default 0
alter table asset add ŞíãÉ_ÇáäİÇíÉ int default 0
alter table asset add ãÌãÚ_ÇáÅåÊáÇß  int default 0

drop table asset_debit

--ãÏíä
create table asset_debit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ãä varchar(100) default '',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
asset_id int  foreign key references   asset(ÇáÑŞã)
)

drop table asset_credit

--ÏÇÆä
create table asset_credit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
Åáì varchar(100) default '',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
asset_id int  foreign key references   asset(ÇáÑŞã)
)



drop table paper_receive

create table paper_receive(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ÊÇÑíÎ  datetime,
ÊÇÑíÎ_ÇáÅÓÊÍŞÇŞ  datetime,
ÇáÓÇÍÈ varchar(50),
ÇáãÓÍæÈ_Úáíå varchar(50))


drop table paper_receive_debit

--ãÏíä
create table paper_receive_debit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ãä varchar(100) default '',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
paper_receive_id int  foreign key references   paper_receive(ÇáÑŞã)
)

drop table paper_receive_credit

--ÏÇÆä
create table paper_receive_credit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
Åáì varchar(100) default '',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
paper_receive_id int  foreign key references   paper_receive(ÇáÑŞã)
)


drop table paper_pay

create table paper_pay(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ÊÇÑíÎ  datetime,
ÊÇÑíÎ_ÇáÅÓÊÍŞÇŞ  datetime,
ÇáÓÇÍÈ varchar(50),
ÇáãÓÍæÈ_Úáíå varchar(50))

drop table paper_pay_debit

--ãÏíä
create table paper_pay_debit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ãä varchar(100) default '',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
paper_receive_id int  foreign key references   paper_pay(ÇáÑŞã)
)

drop table paper_pay_credit

--ÏÇÆä
create table paper_pay_credit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
Åáì varchar(100) default '',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
paper_receive_id int  foreign key references   paper_pay(ÇáÑŞã)
)


create table liability(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÅáÊÒÇã varchar(20)not null,
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ÊÇÑíÎ datetime not null,
)
alter table liability add äæÚ_ÇáÅáÊÒÇã  varchar(100)
alter table liability add äÓÈÉ_ÇáİÇÆÏÉ  int default 0

drop table liability_debit

--ãÏíä
create table liability_debit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
ãä varchar(100) default '',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
liability_id int  foreign key references   liability(ÇáÑŞã)
)

drop table liability_credit

--ÏÇÆä
create table liability_credit(
ÇáÑŞã int not null primary key identity(1,1),
ÇáÑÕíÏ float not null default 0,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
Åáì varchar(100) default '',
ãáÇÍØÇÊ varchar(max),
ÊÇÑíÎ  datetime,
liability_id int  foreign key references   liability(ÇáÑŞã)
)

drop table error

create table error(
ÇáÑŞã int not null primary key identity(1,1),
class varchar(50),
error_ms varchar(max),
error_row int
)

drop table material_maker

create table material_maker(
ÇáÑŞã int not null primary key identity(1,1),
ÇÓã_ÇáãÇÏÉ varchar(100) not null ,
ÇáæÍÏÉ varchar(20) not null ,
ßãíÉ int not null default 0,
ÇáßáİÉ float not null default 0 ,
ÓÚÑ_ÇáÈíÚ float not null default 0 ,
ÇáãÌãæÚÉ int  foreign key references   material_group(ÑŞã_ÇáãÌãæÚÉ) default 0 ,
ÇáãÓÊæÏÚ int  foreign key references WareHouse(ÑŞã_ÇáãÓÊæÏÚ) default 0
)
alter table material_maker add ßáİ int 
alter table material_maker add ÇáãÓÊæÏÚ int 
alter table material_maker add ÇáãÓÊæÏÚ int 

drop table material_maker_list

create table material_maker_list(
ÑŞã_ÇáãÇÏÉ int not null foreign key references material(ÇáÑŞã_Çáİäí),
ÑŞã_ÇáãÕäÚ int not null foreign key references material_maker(ÇáÑŞã),
ÇÓã_ÇáãÇÏÉ varchar(100) not null ,
ÇáæÍÏÉ varchar(20) not null ,
ßãíÉ int not null default 0,
ÓÚÑ_ÇáÔÑÇÁ float not null default 0 ,
äÓÈÉ_ÇáåÏÑ float not null default 0 ,
ßáİÉ_ÇáãÇÏÉ float not null default 0 ,
ãáÇÍÙÇÊ varchar(100) not null 
)


-----------------------------------
drop table materialMaker_credit

create table  materialMaker_credit(
ÇáÑŞã int not null primary key identity(1,1) ,
ÊÇÑíÎ_ÈÏÇíÉ_ÇáÊÕäíÚ datetime not null ,
ÊÇÑíÎ_äåÇíÉ_ÇáÊÕäíÚ datetime not null ,
ÇáßáİÉ float not null,
ÇáÑÕíÏ_ßÊÇÈÉ varchar(150) not null default 'ÕİÑ',
Åáì varchar(100) ,
ÇáãÓÊæÏÚ varchar(10),
)
alter table materialMaker_credit add åÏÑ float default 0 
alter table materialMaker_credit add ãÕÇÑíİ_ãÖÇİÉ float default 0 
alter table materialMaker_credit add ßãíÉ_ÇáÅäÊÇÌ float default 0 


-- ÇãÇ ÈíÚ Ãæ ÑÏø ãÔÊÑíÇÊ 



drop table materialMaker_credit_list
--ãæÇÏ ÏÇÆä
create table materialMaker_credit_list(
ÑŞã_ÇáãÇÏÉ int not null foreign key references material(ÇáÑŞã_Çáİäí),
ÑŞã_ÇáÊŞÑíÑ int not null foreign key references materialMaker_credit(ÇáÑŞã),
ÇÓã_ÇáãÇÏÉ varchar(100) not null ,
ÇáæÍÏÉ varchar(20) not null ,
ÇáßãíÉ int not null ,
ÇáÓÚÑ float not null ,	
ÇáÓÚÑ_ÇáÌãÇáí float not null ,
ãáÇÍÙÇÊ varchar(50) 
)
alter table materialMaker_credit_list add ÇáãÓÊæÏÚ int 
alter table materialMaker_credit_list add ÇáåÏÑ float default 0 
