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
���_�������� int not null primary key ,
���_�������� varchar(100) not null default ''
)
 
drop table producer 

create table producer(
���_������ int not null primary key ,
���_������ varchar(60) not null default '',
���_����� varchar(50) not null default '',
)

drop table WareHouse

create table WareHouse(
���_�������� int not null primary key ,
���_��������  varchar(50) not null default ''
)

drop table material

create table material(
�����_����� int not null primary key identity(1,1),
���_������ varchar(100) not null ,
�����_������ varchar(50),
������ varchar(20) not null ,
���� int not null default 0,
��� float not null default 0 ,
���_������ varchar(30),
�������� int  foreign key references   material_group(���_��������) default 0 ,
������ int  foreign key references   producer(���_������) default 0,
�������� int  foreign key references WareHouse(���_��������) default 0
)
--alter table material add ������ int foreign key references machine_type(�����) default 0
alter table material add ���� varchar(6) default 'false'
alter table material add ���_������  varchar(max)
alter table material add ����  varchar(100)
alter table material add ���_�����  int default 0
alter table material add ���_������  int default 0
alter table material add ���_������  int default 0
alter table material add ���_�����  int default 0
alter table material add ���_������  varchar(30) default ''
alter table material add �����_����_������  varchar(10)


drop table material_cost

create table material_cost( 
������ int  foreign key references material(�����_�����) ,
���_������ int not null ,
���� int not null default 0,
������� datetime
)
alter table material_cost add ���_������_������  int


drop table customer

create table customer(
����� int not null primary key identity(0,1),
���_������ varchar(50) not null unique,
������ float not null default 0,
������_����� varchar(150) not null default '���',
�����_������ varchar(100),
���� varchar(20),
�������� varchar(20),
������_���������� varchar(50),
������_���������� varchar(50),
����� datetime,
���_������ varchar(max),
���� varchar(100)
)

INSERT INTO [Computer].[dbo].[customer]
           ([���_������]
           ,[������]
           ,[������_�����]
           ,[�����_������]
           ,[����]
           ,[��������]
           ,[������_����������]
           ,[������_����������]
           ,[�����]
           ,[���_������]
           ,[����])
     VALUES
           ('��� �����'
           ,0
           ,'���'
           ,''
           ,''
           ,''
           ,''
           ,''
           ,GETDATE ( )
           ,''
           ,'')


drop table customer_debit

--����
create table customer_debit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
�� varchar(100) default '����� ����� ����� ',
������� varchar(max),
�����  datetime,
customer_id int  foreign key references   customer(�����)
)

drop table customer_credit

--����
create table customer_credit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
��� varchar(100) default ' ����� ���� ������� ',
������� varchar(max),
�����  datetime,
customer_id int  foreign key references   customer(�����)
)

create table customer_ReveiveTime(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
������� varchar(max),
�����  datetime,
customer_id int  foreign key references   customer(�����)
)
alter table customer_ReveiveTime add ��_����� varchar(10) default 'false' 


drop table supplier

create table supplier(
����� int not null primary key identity(0,1),
���_������ varchar(50) not null unique,
������ float not null default 0 ,
������_����� varchar(150) not null default '���' ,
�����_������ varchar(100),
���� varchar(20),
�������� varchar(20),
������_���������� varchar(50),
������_���������� varchar(50),
����� datetime ,
���_������ varchar(max),
���� varchar(100)
)

INSERT INTO [Computer].[dbo].[supplier]
           ([���_������]
           ,[������]
           ,[������_�����]
           ,[�����_������]
           ,[����]
           ,[��������]
           ,[������_����������]
           ,[������_����������]
           ,[�����]
           ,[���_������]
           ,[����])
     VALUES
           ('��� �����'
           ,0
           ,'���'
           ,''
           ,''
           ,''
           ,''
           ,''
           ,GETDATE ( )
           ,''
           ,'')

drop table supplier_debit

--����
create table supplier_debit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
�� varchar(100) default '����� ���� ������ ',
������� varchar(max),
�����  datetime,
Supplier_id int  foreign key references   supplier(�����)
)

drop table supplier_credit

--����
create table supplier_credit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
��� varchar(100) default '������� ����� �� ������ ',
������� varchar(max),
�����  datetime,
Supplier_id int  foreign key references   supplier(�����)
)

create table supplier_PayTime(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
������� varchar(max),
�����  datetime,
Supplier_id int  foreign key references   supplier(�����)
)
alter table supplier_PayTime add ��_����� varchar(10) default 'false'



Drop table material_debit
--����
create table material_debit(
����� int not null primary key identity(1,1) ,
����� datetime not null ,
������ float not null,
�� varchar(100) ,
������_����� varchar(150) not null default '���',
���_������_������ int  ,
�����_������_������ datetime  ,
������ varchar(40),
�������� varchar(10) ,
������ int not null foreign key references supplier(�����),
)
alter table material_debit add ���� varchar(5) default ''
alter table material_debit add ���_������� varchar(10) default '����' 
alter table material_debit add ���_����� float default 0 
alter table material_debit add ������_����� float default 0 
alter table material_debit add ������_���_���� varchar(20)  
alter table material_debit add ���� varchar(5)   --true or false �� ����� ������
alter table material_debit add �����_����� varchar(10)  
alter table material_debit add ���_������ varchar(30) 
alter table material_debit add ���_����� int default 0






/**/
drop table material_debit_list
--���� ����
create table material_debit_list(
���_������ int not null foreign key references material(�����_�����),
���_������� int not null foreign key references material_debit(�����),
���_������ varchar(100) not null ,
������ varchar(20) not null ,
������ int not null ,
����� float not null ,	
�����_������� float not null ,
������� varchar(50) 
)
alter table material_debit_list add �������� int 
alter table material_debit_list add ������_����� varchar(50)
alter table material_debit_list add ���� varchar(5) default ''
alter table material_debit_list add ���_����� float default 0 

drop table material_debit_penfit_payment
--���� ����
create table material_debit_penfit_payment(
���_������� int not null foreign key references material_debit(�����),
������� int not null,
����_������� int not null,
�����_�� int not null,
���_������� int not null)
alter table material_debit_penfit_payment add ������� int default 0


Drop table material_debit_return
--����
create table material_debit_return(
����� int not null primary key identity(1,1) ,
����� datetime not null ,
������ float not null,
�� varchar(100) ,
������_����� varchar(150) not null default '���',
���_������_������ int  ,
�����_������_������ datetime  ,
������ varchar(40),
�������� varchar(10) ,
������ int not null foreign key references customer(�����),
)
alter table material_debit_return add ���� varchar(5) default ''
alter table material_debit_return add ���_������� varchar(10) default '����' 
alter table material_debit_return add ���_����� float default 0 
alter table material_debit_return add ������_����� float default 0 
alter table material_debit_return add ������_���_���� varchar(20)  
alter table material_debit_return add ���� varchar(5)   --true or false �� ����� ������
alter table material_debit_return add �����_����� varchar(10)  
alter table material_debit_return add ���_������ varchar(30) 
alter table material_debit_return add ������ float 


-- ��� ���� �� ��� ����� 


/**/
drop table material_debit_list_return
--���� ����
create table material_debit_list_return(
���_������ int not null foreign key references material(�����_�����),
���_������� int not null foreign key references material_debit_return(�����),
���_������ varchar(100) not null ,
������ varchar(20) not null ,
������ int not null ,
����� float not null ,	
�����_������� float not null ,
������� varchar(50) 
)
alter table material_debit_list_return add �������� int 
alter table material_debit_list_return add ������_����� varchar(50)
alter table material_debit_list_return add ���� varchar(5) default ''
alter table material_debit_list_return add ���_����� float default 0 
alter table material_debit_list_return add ���_������ int 
alter table material_debit_list_return add ������ float 




drop table material_credit
--����
create table  material_credit(
����� int not null primary key identity(1,1) ,
�����_����� datetime not null ,
�����_������� datetime not null ,
������ float not null,
������_����� varchar(150) not null default '���',
��� varchar(100) ,
�����_����� varchar(20),--���� �� ����
�������� varchar(10),
������ int not null foreign key references customer(�����)
)
alter table material_credit add ���� varchar(5) default ''
alter table material_credit add ���� varchar(5) default ''
alter table material_credit add ���_������� varchar(30) default '���' 
alter table material_credit add ���_����� float default 0 
alter table material_credit add ������_����� float default 0 
alter table material_credit add ������_���_���� varchar(20)  
alter table material_credit add ���� varchar(5)   --true or false �� ����� ������
alter table material_credit add ���_������ varchar(30) 
alter table material_credit add ���_����� int default 0
alter table material_credit add ������� int default 0
alter table material_credit add �����_�� int default 0
alter table material_credit add ���_������� int default 0
alter table material_credit add ������ float 


-- ��� ��� �� ��� ������� 



drop table material_credit_list
--���� ����
create table material_credit_list(
���_������ int not null foreign key references material(�����_�����),
���_������� int not null foreign key references material_credit(�����),
���_������ varchar(100) not null ,
������ varchar(20) not null ,
������ int not null ,
����� float not null ,	
�����_������� float not null ,
������� varchar(50) 
)
alter table material_credit_list add �������� int 
alter table material_credit_list add ������_����� varchar(50)
alter table material_credit_list add ���� varchar(5) default ''
alter table material_credit_list add ���_����� float default 0 
alter table material_credit_list add ���_������ int 
alter table material_credit_list add ������ float 


drop table material_credit_penfit_payment
--���� ����
create table material_credit_penfit_payment(
���_������� int not null foreign key references material_credit(�����),
������� int not null,
����_������� int not null,
�����_�� int not null,
���_������� int not null)
alter table material_credit_penfit_payment add ������� int default 0



drop table material_credit_return
--����
create table  material_credit_return(
����� int not null primary key identity(1,1) ,
�����_����� datetime not null ,
�����_������� datetime not null ,
������ float not null,
������_����� varchar(150) not null default '���',
��� varchar(100) ,
�����_����� varchar(20),--���� �� ����
�������� varchar(10),
������ int not null foreign key references supplier(�����)
)
alter table material_credit_return add ���� varchar(5) default ''
alter table material_credit_return add ���� varchar(5) default ''
alter table material_credit_return add ���_������� varchar(30) default '���' 
alter table material_credit_return add ���_����� float default 0 
alter table material_credit_return add ������_����� float default 0 
alter table material_credit_return add ������_���_���� varchar(20)  
alter table material_credit_return add ���� varchar(5)   --true or false �� ����� ������
alter table material_credit_return add ���_������ varchar(30) 

-- ��� ��� �� ��� ������� 

drop table material_credit_list_return
--���� ����
create table material_credit_list_return(
���_������ int not null foreign key references material(�����_�����),
���_������� int not null foreign key references material_credit_return(�����),
���_������ varchar(100) not null ,
������ varchar(20) not null ,
������ int not null ,
����� float not null ,	
�����_������� float not null ,
������� varchar(50) 
)
alter table material_credit_list_return add �������� int 
alter table material_credit_list_return add ������_����� varchar(50)
alter table material_credit_list_return add ���� varchar(5) default ''
alter table material_credit_list_return add ���_����� float default 0 

/**/
drop table box
--���� ����
create table box(
����� int not null primary key identity(1,1),
���_������� varchar(20)not null,
������ float not null default 0,
������_����� varchar(150) not null default '���',
����� datetime not null,
)

INSERT INTO [Computer].[dbo].[box]
           ([���_�������]
           ,[������]
           ,[������_�����]
           ,[�����])
     VALUES
           ('����� �������'
           ,0
           ,'���'
           ,CURRENT_TIMESTAMP)
GO

drop table box_debit

--����
create table box_debit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
�� varchar(100) default ' ����� ����',
������� varchar(max),
�����  datetime,
box_id int  foreign key references   box(�����),
)

drop table box_credit

--����
create table box_credit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
��� varchar(100) default ' ����� ���� ',
������� varchar(max),
�����  datetime,
box_id int  foreign key references   box(�����)
)


drop table bank_details

create table bank_details(
����� int not null primary key identity(1,1),
���_�����  varchar(50) not null ,
�����_����� varchar(100),
���� varchar(20),
�������� varchar(20),
������_���������� varchar(50),
������_���������� varchar(50)
)
alter table bank_details add ����� varchar(100) 


drop table bank_account

create table bank_account(
����� int not null primary key identity(1,1),
���_������ varchar(50) not null ,
���_������ varchar(20) not null,
���_������ varchar(30)not null,
������ float not null default 0,
������_����� varchar(150) not null default '���',
����� datetime not null,
bank_id int  foreign key references   bank_details(�����)
)
alter table bank_account add ����� varchar(100) 


drop table bank_debit

--����
create table bank_debit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
�� varchar(100) default ' ',
������� varchar(max),
�����  datetime,
bank_id int  foreign key references   bank_account(�����),
)

drop table bank_credit

--����
create table bank_credit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
��� varchar(100) default ' ',
������� varchar(max),
�����  datetime,
bank_id int  foreign key references   bank_account(�����)
)


create table bonds(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
�� varchar(100) default ' ',
��� varchar(100) default ' ',
������� varchar(max),
�����  datetime
)
alter table bonds add   ���� varchar(5)

drop table asset
--���� ����
create table asset(
����� int not null primary key identity(1,1),
���_����� varchar(20)not null,
������ float not null default 0,
������_����� varchar(150) not null default '���',
����� datetime not null,
)
alter table asset add ���_�����  varchar(100)
alter table asset add ����_��������  int default 0
alter table asset add ����_������� int default 0
alter table asset add ����_��������  int default 0

drop table asset_debit

--����
create table asset_debit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
�� varchar(100) default '',
������� varchar(max),
�����  datetime,
asset_id int  foreign key references   asset(�����)
)

drop table asset_credit

--����
create table asset_credit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
��� varchar(100) default '',
������� varchar(max),
�����  datetime,
asset_id int  foreign key references   asset(�����)
)



drop table paper_receive

create table paper_receive(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
�����  datetime,
�����_���������  datetime,
������ varchar(50),
�������_���� varchar(50))


drop table paper_receive_debit

--����
create table paper_receive_debit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
�� varchar(100) default '',
������� varchar(max),
�����  datetime,
paper_receive_id int  foreign key references   paper_receive(�����)
)

drop table paper_receive_credit

--����
create table paper_receive_credit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
��� varchar(100) default '',
������� varchar(max),
�����  datetime,
paper_receive_id int  foreign key references   paper_receive(�����)
)


drop table paper_pay

create table paper_pay(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
�����  datetime,
�����_���������  datetime,
������ varchar(50),
�������_���� varchar(50))

drop table paper_pay_debit

--����
create table paper_pay_debit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
�� varchar(100) default '',
������� varchar(max),
�����  datetime,
paper_receive_id int  foreign key references   paper_pay(�����)
)

drop table paper_pay_credit

--����
create table paper_pay_credit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
��� varchar(100) default '',
������� varchar(max),
�����  datetime,
paper_receive_id int  foreign key references   paper_pay(�����)
)


create table liability(
����� int not null primary key identity(1,1),
�������� varchar(20)not null,
������ float not null default 0,
������_����� varchar(150) not null default '���',
����� datetime not null,
)
alter table liability add ���_��������  varchar(100)
alter table liability add ����_�������  int default 0

drop table liability_debit

--����
create table liability_debit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
�� varchar(100) default '',
������� varchar(max),
�����  datetime,
liability_id int  foreign key references   liability(�����)
)

drop table liability_credit

--����
create table liability_credit(
����� int not null primary key identity(1,1),
������ float not null default 0,
������_����� varchar(150) not null default '���',
��� varchar(100) default '',
������� varchar(max),
�����  datetime,
liability_id int  foreign key references   liability(�����)
)

drop table error

create table error(
����� int not null primary key identity(1,1),
class varchar(50),
error_ms varchar(max),
error_row int
)

drop table material_maker

create table material_maker(
����� int not null primary key identity(1,1),
���_������ varchar(100) not null ,
������ varchar(20) not null ,
���� int not null default 0,
������ float not null default 0 ,
���_����� float not null default 0 ,
�������� int  foreign key references   material_group(���_��������) default 0 ,
�������� int  foreign key references WareHouse(���_��������) default 0
)
alter table material_maker add ��� int 
alter table material_maker add �������� int 
alter table material_maker add �������� int 

drop table material_maker_list

create table material_maker_list(
���_������ int not null foreign key references material(�����_�����),
���_������ int not null foreign key references material_maker(�����),
���_������ varchar(100) not null ,
������ varchar(20) not null ,
���� int not null default 0,
���_������ float not null default 0 ,
����_����� float not null default 0 ,
����_������ float not null default 0 ,
������� varchar(100) not null 
)


-----------------------------------
drop table materialMaker_credit

create table  materialMaker_credit(
����� int not null primary key identity(1,1) ,
�����_�����_������� datetime not null ,
�����_�����_������� datetime not null ,
������ float not null,
������_����� varchar(150) not null default '���',
��� varchar(100) ,
�������� varchar(10),
)
alter table materialMaker_credit add ��� float default 0 
alter table materialMaker_credit add ������_����� float default 0 
alter table materialMaker_credit add ����_������� float default 0 


-- ��� ��� �� ��� ������� 



drop table materialMaker_credit_list
--���� ����
create table materialMaker_credit_list(
���_������ int not null foreign key references material(�����_�����),
���_������� int not null foreign key references materialMaker_credit(�����),
���_������ varchar(100) not null ,
������ varchar(20) not null ,
������ int not null ,
����� float not null ,	
�����_������� float not null ,
������� varchar(50) 
)
alter table materialMaker_credit_list add �������� int 
alter table materialMaker_credit_list add ����� float default 0 
