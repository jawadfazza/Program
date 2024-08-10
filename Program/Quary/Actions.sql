-- Insert standard operation categories into action_caticory
INSERT INTO action_caticory (ID, caticory, description, created_at) VALUES
    (NEWID(), 'User Profile Management', 'Operations related to user profile management', CURRENT_TIMESTAMP),
    (NEWID(), 'User Login History Management', 'Operations related to user login history', CURRENT_TIMESTAMP),
    (NEWID(), 'Action Category Management', 'Operations related to action category management', CURRENT_TIMESTAMP),
    (NEWID(), 'Action Management', 'Operations related to action management', CURRENT_TIMESTAMP),
    (NEWID(), 'User Permission Management', 'Operations related to user permission management', CURRENT_TIMESTAMP),
    (NEWID(), 'Company Management', 'Operations related to company management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Group Management', 'Operations related to material group management', CURRENT_TIMESTAMP),
    (NEWID(), 'Producer Management', 'Operations related to producer management', CURRENT_TIMESTAMP),
    (NEWID(), 'Warehouse Management', 'Operations related to warehouse management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Management', 'Operations related to material management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Cost Management', 'Operations related to material cost management', CURRENT_TIMESTAMP),
    (NEWID(), 'Customer Management', 'Operations related to customer management', CURRENT_TIMESTAMP),
    (NEWID(), 'Customer Debit Management', 'Operations related to customer debit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Customer Credit Management', 'Operations related to customer credit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Customer Receive Time Management', 'Operations related to customer receive time management', CURRENT_TIMESTAMP),
    (NEWID(), 'Supplier Management', 'Operations related to supplier management', CURRENT_TIMESTAMP),
    (NEWID(), 'Supplier Debit Management', 'Operations related to supplier debit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Supplier Credit Management', 'Operations related to supplier credit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Supplier Pay Time Management', 'Operations related to supplier pay time management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Debit Management', 'Operations related to material debit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Debit List Management', 'Operations related to material debit list management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Debit Benefit Payment Management', 'Operations related to material debit benefit payment management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Debit Return Management', 'Operations related to material debit return management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Debit List Return Management', 'Operations related to material debit list return management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Credit Management', 'Operations related to material credit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Credit List Management', 'Operations related to material credit list management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Credit Benefit Payment Management', 'Operations related to material credit benefit payment management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Credit Return Management', 'Operations related to material credit return management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Credit List Return Management', 'Operations related to material credit list return management', CURRENT_TIMESTAMP),
    (NEWID(), 'Box Management', 'Operations related to box management', CURRENT_TIMESTAMP),
    (NEWID(), 'Box Debit Management', 'Operations related to box debit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Box Credit Management', 'Operations related to box credit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Bank Details Management', 'Operations related to bank details management', CURRENT_TIMESTAMP),
    (NEWID(), 'Bank Account Management', 'Operations related to bank account management', CURRENT_TIMESTAMP),
    (NEWID(), 'Bank Debit Management', 'Operations related to bank debit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Bank Credit Management', 'Operations related to bank credit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Bonds Management', 'Operations related to bonds management', CURRENT_TIMESTAMP),
    (NEWID(), 'Asset Management', 'Operations related to asset management', CURRENT_TIMESTAMP),
    (NEWID(), 'Asset Debit Management', 'Operations related to asset debit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Asset Credit Management', 'Operations related to asset credit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Paper Receive Management', 'Operations related to paper receive management', CURRENT_TIMESTAMP),
    (NEWID(), 'Paper Receive Debit Management', 'Operations related to paper receive debit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Paper Receive Credit Management', 'Operations related to paper receive credit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Paper Pay Management', 'Operations related to paper pay management', CURRENT_TIMESTAMP),
    (NEWID(), 'Paper Pay Debit Management', 'Operations related to paper pay debit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Paper Pay Credit Management', 'Operations related to paper pay credit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Liability Management', 'Operations related to liability management', CURRENT_TIMESTAMP),
    (NEWID(), 'Liability Debit Management', 'Operations related to liability debit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Liability Credit Management', 'Operations related to liability credit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Error Management', 'Operations related to error management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Maker Management', 'Operations related to material maker management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Maker List Management', 'Operations related to material maker list management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Maker Credit Management', 'Operations related to material maker credit management', CURRENT_TIMESTAMP),
    (NEWID(), 'Material Maker Credit List Management', 'Operations related to material maker credit list management', CURRENT_TIMESTAMP);

-- Retrieve IDs for action categories
DECLARE @UserProfileManagementID uniqueidentifier;
DECLARE @UserLoginHistoryManagementID uniqueidentifier;
DECLARE @ActionCategoryManagementID uniqueidentifier;
DECLARE @ActionManagementID uniqueidentifier;
DECLARE @UserPermissionManagementID uniqueidentifier;
DECLARE @CompanyManagementID uniqueidentifier;
DECLARE @MaterialGroupManagementID uniqueidentifier;
DECLARE @ProducerManagementID uniqueidentifier;
DECLARE @WarehouseManagementID uniqueidentifier;
DECLARE @MaterialManagementID uniqueidentifier;
DECLARE @MaterialCostManagementID uniqueidentifier;
DECLARE @CustomerManagementID uniqueidentifier;
DECLARE @CustomerDebitManagementID uniqueidentifier;
DECLARE @CustomerCreditManagementID uniqueidentifier;
DECLARE @CustomerReceiveTimeManagementID uniqueidentifier;
DECLARE @SupplierManagementID uniqueidentifier;
DECLARE @SupplierDebitManagementID uniqueidentifier;
DECLARE @SupplierCreditManagementID uniqueidentifier;
DECLARE @SupplierPayTimeManagementID uniqueidentifier;
DECLARE @MaterialDebitManagementID uniqueidentifier;
DECLARE @MaterialDebitListManagementID uniqueidentifier;
DECLARE @MaterialDebitBenefitPaymentManagementID uniqueidentifier;
DECLARE @MaterialDebitReturnManagementID uniqueidentifier;
DECLARE @MaterialDebitListReturnManagementID uniqueidentifier;
DECLARE @MaterialCreditManagementID uniqueidentifier;
DECLARE @MaterialCreditListManagementID uniqueidentifier;
DECLARE @MaterialCreditBenefitPaymentManagementID uniqueidentifier;
DECLARE @MaterialCreditReturnManagementID uniqueidentifier;
DECLARE @MaterialCreditListReturnManagementID uniqueidentifier;
DECLARE @BoxManagementID uniqueidentifier;
DECLARE @BoxDebitManagementID uniqueidentifier;
DECLARE @BoxCreditManagementID uniqueidentifier;
DECLARE @BankDetailsManagementID uniqueidentifier;
DECLARE @BankAccountManagementID uniqueidentifier;
DECLARE @BankDebitManagementID uniqueidentifier;
DECLARE @BankCreditManagementID uniqueidentifier;
DECLARE @BondsManagementID uniqueidentifier;
DECLARE @AssetManagementID uniqueidentifier;
DECLARE @AssetDebitManagementID uniqueidentifier;
DECLARE @AssetCreditManagementID uniqueidentifier;
DECLARE @PaperReceiveManagementID uniqueidentifier;
DECLARE @PaperReceiveDebitManagementID uniqueidentifier;
DECLARE @PaperReceiveCreditManagementID uniqueidentifier;
DECLARE @PaperPayManagementID uniqueidentifier;
DECLARE @PaperPayDebitManagementID uniqueidentifier;
DECLARE @PaperPayCreditManagementID uniqueidentifier;
DECLARE @LiabilityManagementID uniqueidentifier;
DECLARE @LiabilityDebitManagementID uniqueidentifier;
DECLARE @LiabilityCreditManagementID uniqueidentifier;
DECLARE @ErrorManagementID uniqueidentifier;
DECLARE @MaterialMakerManagementID uniqueidentifier;
DECLARE @MaterialMakerListManagementID uniqueidentifier;
DECLARE @MaterialMakerCreditManagementID uniqueidentifier;
DECLARE @MaterialMakerCreditListManagementID uniqueidentifier;

SET @UserProfileManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'User Profile Management');
SET @UserLoginHistoryManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'User Login History Management');
SET @ActionCategoryManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Action Category Management');
SET @ActionManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Action Management');
SET @UserPermissionManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'User Permission Management');
SET @CompanyManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Company Management');
SET @MaterialGroupManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Group Management');
SET @ProducerManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Producer Management');
SET @WarehouseManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Warehouse Management');
SET @MaterialManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Management');
SET @MaterialCostManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Cost Management');
SET @CustomerManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Customer Management');
SET @CustomerDebitManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Customer Debit Management');
SET @CustomerCreditManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Customer Credit Management');
SET @CustomerReceiveTimeManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Customer Receive Time Management');
SET @SupplierManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Supplier Management');
SET @SupplierDebitManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Supplier Debit Management');
SET @SupplierCreditManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Supplier Credit Management');
SET @SupplierPayTimeManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Supplier Pay Time Management');
SET @MaterialDebitManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Debit Management');
SET @MaterialDebitListManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Debit List Management');
SET @MaterialDebitBenefitPaymentManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Debit Benefit Payment Management');
SET @MaterialDebitReturnManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Debit Return Management');
SET @MaterialDebitListReturnManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Debit List Return Management');
SET @MaterialCreditManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Credit Management');
SET @MaterialCreditListManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Credit List Management');
SET @MaterialCreditBenefitPaymentManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Credit Benefit Payment Management');
SET @MaterialCreditReturnManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Credit Return Management');
SET @MaterialCreditListReturnManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Credit List Return Management');
SET @BoxManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Box Management');
SET @BoxDebitManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Box Debit Management');
SET @BoxCreditManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Box Credit Management');
SET @BankDetailsManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Bank Details Management');
SET @BankAccountManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Bank Account Management');
SET @BankDebitManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Bank Debit Management');
SET @BankCreditManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Bank Credit Management');
SET @BondsManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Bonds Management');
SET @AssetManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Asset Management');
SET @AssetDebitManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Asset Debit Management');
SET @AssetCreditManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Asset Credit Management');
SET @PaperReceiveManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Paper Receive Management');
SET @PaperReceiveDebitManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Paper Receive Debit Management');
SET @PaperReceiveCreditManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Paper Receive Credit Management');
SET @PaperPayManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Paper Pay Management');
SET @PaperPayDebitManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Paper Pay Debit Management');
SET @PaperPayCreditManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Paper Pay Credit Management');
SET @LiabilityManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Liability Management');
SET @LiabilityDebitManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Liability Debit Management');
SET @LiabilityCreditManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Liability Credit Management');
SET @ErrorManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Error Management');
SET @MaterialMakerManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Maker Management');
SET @MaterialMakerListManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Maker List Management');
SET @MaterialMakerCreditManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Maker Credit Management');
SET @MaterialMakerCreditListManagementID = (SELECT ID FROM action_caticory WHERE caticory = 'Material Maker Credit List Management');

-- Insert standard actions into action table for each category
INSERT INTO action (ID, caticory_id, action_description, created_at) VALUES
    -- User Profile Management Actions
    (NEWID(), @UserProfileManagementID, 'Add User Profile', CURRENT_TIMESTAMP),
    (NEWID(), @UserProfileManagementID, 'Remove User Profile', CURRENT_TIMESTAMP),
    (NEWID(), @UserProfileManagementID, 'Update User Profile', CURRENT_TIMESTAMP),
    (NEWID(), @UserProfileManagementID, 'View User Profile', CURRENT_TIMESTAMP),

    -- User Login History Management Actions
    (NEWID(), @UserLoginHistoryManagementID, 'Add User Login History', CURRENT_TIMESTAMP),
    (NEWID(), @UserLoginHistoryManagementID, 'Remove User Login History', CURRENT_TIMESTAMP),
    (NEWID(), @UserLoginHistoryManagementID, 'Update User Login History', CURRENT_TIMESTAMP),
    (NEWID(), @UserLoginHistoryManagementID, 'View User Login History', CURRENT_TIMESTAMP),

    -- Action Category Management Actions
    (NEWID(), @ActionCategoryManagementID, 'Add Action Category', CURRENT_TIMESTAMP),
    (NEWID(), @ActionCategoryManagementID, 'Remove Action Category', CURRENT_TIMESTAMP),
    (NEWID(), @ActionCategoryManagementID, 'Update Action Category', CURRENT_TIMESTAMP),
    (NEWID(), @ActionCategoryManagementID, 'View Action Category', CURRENT_TIMESTAMP),

    -- Action Management Actions
    (NEWID(), @ActionManagementID, 'Add Action', CURRENT_TIMESTAMP),
    (NEWID(), @ActionManagementID, 'Remove Action', CURRENT_TIMESTAMP),
    (NEWID(), @ActionManagementID, 'Update Action', CURRENT_TIMESTAMP),
    (NEWID(), @ActionManagementID, 'View Action', CURRENT_TIMESTAMP),

    -- User Permission Management Actions
    (NEWID(), @UserPermissionManagementID, 'Add User Permission', CURRENT_TIMESTAMP),
    (NEWID(), @UserPermissionManagementID, 'Remove User Permission', CURRENT_TIMESTAMP),
    (NEWID(), @UserPermissionManagementID, 'Update User Permission', CURRENT_TIMESTAMP),
    (NEWID(), @UserPermissionManagementID, 'View User Permission', CURRENT_TIMESTAMP),

    -- Company Management Actions
    (NEWID(), @CompanyManagementID, 'Add Company', CURRENT_TIMESTAMP),
    (NEWID(), @CompanyManagementID, 'Remove Company', CURRENT_TIMESTAMP),
    (NEWID(), @CompanyManagementID, 'Update Company', CURRENT_TIMESTAMP),
    (NEWID(), @CompanyManagementID, 'View Company', CURRENT_TIMESTAMP),

    -- Material Group Management Actions
    (NEWID(), @MaterialGroupManagementID, 'Add Material Group', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialGroupManagementID, 'Remove Material Group', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialGroupManagementID, 'Update Material Group', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialGroupManagementID, 'View Material Group', CURRENT_TIMESTAMP),

    -- Producer Management Actions
    (NEWID(), @ProducerManagementID, 'Add Producer', CURRENT_TIMESTAMP),
    (NEWID(), @ProducerManagementID, 'Remove Producer', CURRENT_TIMESTAMP),
    (NEWID(), @ProducerManagementID, 'Update Producer', CURRENT_TIMESTAMP),
    (NEWID(), @ProducerManagementID, 'View Producer', CURRENT_TIMESTAMP),

    -- Warehouse Management Actions
    (NEWID(), @WarehouseManagementID, 'Add Warehouse', CURRENT_TIMESTAMP),
    (NEWID(), @WarehouseManagementID, 'Remove Warehouse', CURRENT_TIMESTAMP),
    (NEWID(), @WarehouseManagementID, 'Update Warehouse', CURRENT_TIMESTAMP),
    (NEWID(), @WarehouseManagementID, 'View Warehouse', CURRENT_TIMESTAMP),

    -- Material Management Actions
    (NEWID(), @MaterialManagementID, 'Add Material', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialManagementID, 'Remove Material', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialManagementID, 'Update Material', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialManagementID, 'View Material', CURRENT_TIMESTAMP),

    -- Material Cost Management Actions
    (NEWID(), @MaterialCostManagementID, 'Add Material Cost', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCostManagementID, 'Remove Material Cost', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCostManagementID, 'Update Material Cost', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCostManagementID, 'View Material Cost', CURRENT_TIMESTAMP),

    -- Customer Management Actions
    (NEWID(), @CustomerManagementID, 'Add Customer', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerManagementID, 'Remove Customer', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerManagementID, 'Update Customer', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerManagementID, 'View Customer', CURRENT_TIMESTAMP),

    -- Customer Debit Management Actions
    (NEWID(), @CustomerDebitManagementID, 'Add Customer Debit', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerDebitManagementID, 'Remove Customer Debit', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerDebitManagementID, 'Update Customer Debit', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerDebitManagementID, 'View Customer Debit', CURRENT_TIMESTAMP),

    -- Customer Credit Management Actions
    (NEWID(), @CustomerCreditManagementID, 'Add Customer Credit', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerCreditManagementID, 'Remove Customer Credit', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerCreditManagementID, 'Update Customer Credit', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerCreditManagementID, 'View Customer Credit', CURRENT_TIMESTAMP),

    -- Customer Receive Time Management Actions
    (NEWID(), @CustomerReceiveTimeManagementID, 'Add Customer Receive Time', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerReceiveTimeManagementID, 'Remove Customer Receive Time', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerReceiveTimeManagementID, 'Update Customer Receive Time', CURRENT_TIMESTAMP),
    (NEWID(), @CustomerReceiveTimeManagementID, 'View Customer Receive Time', CURRENT_TIMESTAMP),

    -- Supplier Management Actions
    (NEWID(), @SupplierManagementID, 'Add Supplier', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierManagementID, 'Remove Supplier', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierManagementID, 'Update Supplier', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierManagementID, 'View Supplier', CURRENT_TIMESTAMP),

    -- Supplier Debit Management Actions
    (NEWID(), @SupplierDebitManagementID, 'Add Supplier Debit', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierDebitManagementID, 'Remove Supplier Debit', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierDebitManagementID, 'Update Supplier Debit', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierDebitManagementID, 'View Supplier Debit', CURRENT_TIMESTAMP),

    -- Supplier Credit Management Actions
    (NEWID(), @SupplierCreditManagementID, 'Add Supplier Credit', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierCreditManagementID, 'Remove Supplier Credit', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierCreditManagementID, 'Update Supplier Credit', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierCreditManagementID, 'View Supplier Credit', CURRENT_TIMESTAMP),

    -- Supplier Pay Time Management Actions
    (NEWID(), @SupplierPayTimeManagementID, 'Add Supplier Pay Time', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierPayTimeManagementID, 'Remove Supplier Pay Time', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierPayTimeManagementID, 'Update Supplier Pay Time', CURRENT_TIMESTAMP),
    (NEWID(), @SupplierPayTimeManagementID, 'View Supplier Pay Time', CURRENT_TIMESTAMP),

    -- Material Debit Management Actions
    (NEWID(), @MaterialDebitManagementID, 'Add Material Debit', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitManagementID, 'Remove Material Debit', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitManagementID, 'Update Material Debit', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitManagementID, 'View Material Debit', CURRENT_TIMESTAMP),

    -- Material Debit List Management Actions
    (NEWID(), @MaterialDebitListManagementID, 'Add Material Debit List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitListManagementID, 'Remove Material Debit List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitListManagementID, 'Update Material Debit List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitListManagementID, 'View Material Debit List', CURRENT_TIMESTAMP),

    -- Material Debit Benefit Payment Management Actions
    (NEWID(), @MaterialDebitBenefitPaymentManagementID, 'Add Material Debit Benefit Payment', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitBenefitPaymentManagementID, 'Remove Material Debit Benefit Payment', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitBenefitPaymentManagementID, 'Update Material Debit Benefit Payment', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitBenefitPaymentManagementID, 'View Material Debit Benefit Payment', CURRENT_TIMESTAMP),

    -- Material Debit Return Management Actions
    (NEWID(), @MaterialDebitReturnManagementID, 'Add Material Debit Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitReturnManagementID, 'Remove Material Debit Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitReturnManagementID, 'Update Material Debit Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitReturnManagementID, 'View Material Debit Return', CURRENT_TIMESTAMP),

    -- Material Debit List Return Management Actions
    (NEWID(), @MaterialDebitListReturnManagementID, 'Add Material Debit List Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitListReturnManagementID, 'Remove Material Debit List Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitListReturnManagementID, 'Update Material Debit List Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialDebitListReturnManagementID, 'View Material Debit List Return', CURRENT_TIMESTAMP),

    -- Material Credit Management Actions
    (NEWID(), @MaterialCreditManagementID, 'Add Material Credit', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditManagementID, 'Remove Material Credit', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditManagementID, 'Update Material Credit', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditManagementID, 'View Material Credit', CURRENT_TIMESTAMP),

    -- Material Credit List Management Actions
    (NEWID(), @MaterialCreditListManagementID, 'Add Material Credit List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditListManagementID, 'Remove Material Credit List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditListManagementID, 'Update Material Credit List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditListManagementID, 'View Material Credit List', CURRENT_TIMESTAMP),

    -- Material Credit Benefit Payment Management Actions
    (NEWID(), @MaterialCreditBenefitPaymentManagementID, 'Add Material Credit Benefit Payment', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditBenefitPaymentManagementID, 'Remove Material Credit Benefit Payment', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditBenefitPaymentManagementID, 'Update Material Credit Benefit Payment', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditBenefitPaymentManagementID, 'View Material Credit Benefit Payment', CURRENT_TIMESTAMP),

    -- Material Credit Return Management Actions
    (NEWID(), @MaterialCreditReturnManagementID, 'Add Material Credit Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditReturnManagementID, 'Remove Material Credit Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditReturnManagementID, 'Update Material Credit Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditReturnManagementID, 'View Material Credit Return', CURRENT_TIMESTAMP),

    -- Material Credit List Return Management Actions
    (NEWID(), @MaterialCreditListReturnManagementID, 'Add Material Credit List Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditListReturnManagementID, 'Remove Material Credit List Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditListReturnManagementID, 'Update Material Credit List Return', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialCreditListReturnManagementID, 'View Material Credit List Return', CURRENT_TIMESTAMP),

    -- Box Management Actions
    (NEWID(), @BoxManagementID, 'Add Box', CURRENT_TIMESTAMP),
    (NEWID(), @BoxManagementID, 'Remove Box', CURRENT_TIMESTAMP),
    (NEWID(), @BoxManagementID, 'Update Box', CURRENT_TIMESTAMP),
    (NEWID(), @BoxManagementID, 'View Box', CURRENT_TIMESTAMP),

    -- Box Debit Management Actions
    (NEWID(), @BoxDebitManagementID, 'Add Box Debit', CURRENT_TIMESTAMP),
    (NEWID(), @BoxDebitManagementID, 'Remove Box Debit', CURRENT_TIMESTAMP),
    (NEWID(), @BoxDebitManagementID, 'Update Box Debit', CURRENT_TIMESTAMP),
    (NEWID(), @BoxDebitManagementID, 'View Box Debit', CURRENT_TIMESTAMP),

    -- Box Credit Management Actions
    (NEWID(), @BoxCreditManagementID, 'Add Box Credit', CURRENT_TIMESTAMP),
    (NEWID(), @BoxCreditManagementID, 'Remove Box Credit', CURRENT_TIMESTAMP),
    (NEWID(), @BoxCreditManagementID, 'Update Box Credit', CURRENT_TIMESTAMP),
    (NEWID(), @BoxCreditManagementID, 'View Box Credit', CURRENT_TIMESTAMP),

    -- Bank Details Management Actions
    (NEWID(), @BankDetailsManagementID, 'Add Bank Details', CURRENT_TIMESTAMP),
    (NEWID(), @BankDetailsManagementID, 'Remove Bank Details', CURRENT_TIMESTAMP),
    (NEWID(), @BankDetailsManagementID, 'Update Bank Details', CURRENT_TIMESTAMP),
    (NEWID(), @BankDetailsManagementID, 'View Bank Details', CURRENT_TIMESTAMP),

    -- Bank Account Management Actions
    (NEWID(), @BankAccountManagementID, 'Add Bank Account', CURRENT_TIMESTAMP),
    (NEWID(), @BankAccountManagementID, 'Remove Bank Account', CURRENT_TIMESTAMP),
    (NEWID(), @BankAccountManagementID, 'Update Bank Account', CURRENT_TIMESTAMP),
    (NEWID(), @BankAccountManagementID, 'View Bank Account', CURRENT_TIMESTAMP),

    -- Bank Debit Management Actions
    (NEWID(), @BankDebitManagementID, 'Add Bank Debit', CURRENT_TIMESTAMP),
    (NEWID(), @BankDebitManagementID, 'Remove Bank Debit', CURRENT_TIMESTAMP),
    (NEWID(), @BankDebitManagementID, 'Update Bank Debit', CURRENT_TIMESTAMP),
    (NEWID(), @BankDebitManagementID, 'View Bank Debit', CURRENT_TIMESTAMP),

    -- Bank Credit Management Actions
    (NEWID(), @BankCreditManagementID, 'Add Bank Credit', CURRENT_TIMESTAMP),
    (NEWID(), @BankCreditManagementID, 'Remove Bank Credit', CURRENT_TIMESTAMP),
    (NEWID(), @BankCreditManagementID, 'Update Bank Credit', CURRENT_TIMESTAMP),
    (NEWID(), @BankCreditManagementID, 'View Bank Credit', CURRENT_TIMESTAMP),

    -- Bonds Management Actions
    (NEWID(), @BondsManagementID, 'Add Bonds', CURRENT_TIMESTAMP),
    (NEWID(), @BondsManagementID, 'Remove Bonds', CURRENT_TIMESTAMP),
    (NEWID(), @BondsManagementID, 'Update Bonds', CURRENT_TIMESTAMP),
    (NEWID(), @BondsManagementID, 'View Bonds', CURRENT_TIMESTAMP),

    -- Asset Management Actions
    (NEWID(), @AssetManagementID, 'Add Asset', CURRENT_TIMESTAMP),
    (NEWID(), @AssetManagementID, 'Remove Asset', CURRENT_TIMESTAMP),
    (NEWID(), @AssetManagementID, 'Update Asset', CURRENT_TIMESTAMP),
    (NEWID(), @AssetManagementID, 'View Asset', CURRENT_TIMESTAMP),

    -- Asset Debit Management Actions
    (NEWID(), @AssetDebitManagementID, 'Add Asset Debit', CURRENT_TIMESTAMP),
    (NEWID(), @AssetDebitManagementID, 'Remove Asset Debit', CURRENT_TIMESTAMP),
    (NEWID(), @AssetDebitManagementID, 'Update Asset Debit', CURRENT_TIMESTAMP),
    (NEWID(), @AssetDebitManagementID, 'View Asset Debit', CURRENT_TIMESTAMP),

    -- Asset Credit Management Actions
    (NEWID(), @AssetCreditManagementID, 'Add Asset Credit', CURRENT_TIMESTAMP),
    (NEWID(), @AssetCreditManagementID, 'Remove Asset Credit', CURRENT_TIMESTAMP),
    (NEWID(), @AssetCreditManagementID, 'Update Asset Credit', CURRENT_TIMESTAMP),
    (NEWID(), @AssetCreditManagementID, 'View Asset Credit', CURRENT_TIMESTAMP),

    -- Paper Receive Management Actions
    (NEWID(), @PaperReceiveManagementID, 'Add Paper Receive', CURRENT_TIMESTAMP),
    (NEWID(), @PaperReceiveManagementID, 'Remove Paper Receive', CURRENT_TIMESTAMP),
    (NEWID(), @PaperReceiveManagementID, 'Update Paper Receive', CURRENT_TIMESTAMP),
    (NEWID(), @PaperReceiveManagementID, 'View Paper Receive', CURRENT_TIMESTAMP),

    -- Paper Receive Debit Management Actions
    (NEWID(), @PaperReceiveDebitManagementID, 'Add Paper Receive Debit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperReceiveDebitManagementID, 'Remove Paper Receive Debit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperReceiveDebitManagementID, 'Update Paper Receive Debit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperReceiveDebitManagementID, 'View Paper Receive Debit', CURRENT_TIMESTAMP),

    -- Paper Receive Credit Management Actions
    (NEWID(), @PaperReceiveCreditManagementID, 'Add Paper Receive Credit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperReceiveCreditManagementID, 'Remove Paper Receive Credit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperReceiveCreditManagementID, 'Update Paper Receive Credit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperReceiveCreditManagementID, 'View Paper Receive Credit', CURRENT_TIMESTAMP),

    -- Paper Pay Management Actions
    (NEWID(), @PaperPayManagementID, 'Add Paper Pay', CURRENT_TIMESTAMP),
    (NEWID(), @PaperPayManagementID, 'Remove Paper Pay', CURRENT_TIMESTAMP),
    (NEWID(), @PaperPayManagementID, 'Update Paper Pay', CURRENT_TIMESTAMP),
    (NEWID(), @PaperPayManagementID, 'View Paper Pay', CURRENT_TIMESTAMP),

    -- Paper Pay Debit Management Actions
    (NEWID(), @PaperPayDebitManagementID, 'Add Paper Pay Debit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperPayDebitManagementID, 'Remove Paper Pay Debit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperPayDebitManagementID, 'Update Paper Pay Debit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperPayDebitManagementID, 'View Paper Pay Debit', CURRENT_TIMESTAMP),

    -- Paper Pay Credit Management Actions
    (NEWID(), @PaperPayCreditManagementID, 'Add Paper Pay Credit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperPayCreditManagementID, 'Remove Paper Pay Credit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperPayCreditManagementID, 'Update Paper Pay Credit', CURRENT_TIMESTAMP),
    (NEWID(), @PaperPayCreditManagementID, 'View Paper Pay Credit', CURRENT_TIMESTAMP),

    -- Liability Management Actions
    (NEWID(), @LiabilityManagementID, 'Add Liability', CURRENT_TIMESTAMP),
    (NEWID(), @LiabilityManagementID, 'Remove Liability', CURRENT_TIMESTAMP),
    (NEWID(), @LiabilityManagementID, 'Update Liability', CURRENT_TIMESTAMP),
    (NEWID(), @LiabilityManagementID, 'View Liability', CURRENT_TIMESTAMP),

    -- Liability Debit Management Actions
    (NEWID(), @LiabilityDebitManagementID, 'Add Liability Debit', CURRENT_TIMESTAMP),
    (NEWID(), @LiabilityDebitManagementID, 'Remove Liability Debit', CURRENT_TIMESTAMP),
    (NEWID(), @LiabilityDebitManagementID, 'Update Liability Debit', CURRENT_TIMESTAMP),
    (NEWID(), @LiabilityDebitManagementID, 'View Liability Debit', CURRENT_TIMESTAMP),

    -- Liability Credit Management Actions
    (NEWID(), @LiabilityCreditManagementID, 'Add Liability Credit', CURRENT_TIMESTAMP),
    (NEWID(), @LiabilityCreditManagementID, 'Remove Liability Credit', CURRENT_TIMESTAMP),
    (NEWID(), @LiabilityCreditManagementID, 'Update Liability Credit', CURRENT_TIMESTAMP),
    (NEWID(), @LiabilityCreditManagementID, 'View Liability Credit', CURRENT_TIMESTAMP),

    -- Error Management Actions
    (NEWID(), @ErrorManagementID, 'Add Error', CURRENT_TIMESTAMP),
    (NEWID(), @ErrorManagementID, 'Remove Error', CURRENT_TIMESTAMP),
    (NEWID(), @ErrorManagementID, 'Update Error', CURRENT_TIMESTAMP),
    (NEWID(), @ErrorManagementID, 'View Error', CURRENT_TIMESTAMP),

    -- Material Maker Management Actions
    (NEWID(), @MaterialMakerManagementID, 'Add Material Maker', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerManagementID, 'Remove Material Maker', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerManagementID, 'Update Material Maker', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerManagementID, 'View Material Maker', CURRENT_TIMESTAMP),

    -- Material Maker List Management Actions
    (NEWID(), @MaterialMakerListManagementID, 'Add Material Maker List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerListManagementID, 'Remove Material Maker List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerListManagementID, 'Update Material Maker List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerListManagementID, 'View Material Maker List', CURRENT_TIMESTAMP),

    -- Material Maker Credit Management Actions
    (NEWID(), @MaterialMakerCreditManagementID, 'Add Material Maker Credit', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerCreditManagementID, 'Remove Material Maker Credit', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerCreditManagementID, 'Update Material Maker Credit', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerCreditManagementID, 'View Material Maker Credit', CURRENT_TIMESTAMP),

    -- Material Maker Credit List Management Actions
    (NEWID(), @MaterialMakerCreditListManagementID, 'Add Material Maker Credit List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerCreditListManagementID, 'Remove Material Maker Credit List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerCreditListManagementID, 'Update Material Maker Credit List', CURRENT_TIMESTAMP),
    (NEWID(), @MaterialMakerCreditListManagementID, 'View Material Maker Credit List', CURRENT_TIMESTAMP);
