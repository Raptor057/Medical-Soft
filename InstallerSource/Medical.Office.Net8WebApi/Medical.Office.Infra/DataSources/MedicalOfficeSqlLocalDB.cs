using Medical.Office.Domain.Entities.ExpressPos;
using Medical.Office.Domain.Entities.ExpressPos.Views;
using Medical.Office.Domain.Entities.MedicalOffice;
using Medical.Office.Domain.Entities.MedicalOffice.AntecedentPatient;
using Medical.Office.Domain.Entities.MedicalOffice.Views;
using Medical.Office.Domain.Entities.POS;
using Microsoft.Extensions.Logging;

namespace Medical.Office.Infra.DataSources
{
    /// <summary>
    ///
    /// </summary>
    public class MedicalOfficeSqlLocalDB
    {
        private readonly ConfigurationSqlDbConnection<MedicalOfficeSqlLocalDB> _con;
        private readonly ILogger<MedicalOfficeSqlLocalDB> _logger;

        public MedicalOfficeSqlLocalDB(ILogger<MedicalOfficeSqlLocalDB> logger,ConfigurationSqlDbConnection<MedicalOfficeSqlLocalDB> con)
        {
            _con = con;
            _logger=logger;
        }
        

        #region MedicalOffice

        /// <summary>
        ///
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Specialty"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public async Task InsertDoctors(string FirstName, string LastName, string Specialty, string PhoneNumber, string Email)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[Doctors]" +
                "([FirstName],[LastName],[Specialty],[PhoneNumber],[Email])" +
                "VALUES(@FirstName,@LastName,@Specialty,@PhoneNumber,@Email);",
            new { FirstName, LastName, Specialty, PhoneNumber, Email }).ConfigureAwait(false);

        public async Task UpdateDoctor(Doctors doctor)
            => await _con.ExecuteAsync(@"Update Doctors SET FirstName = @FirstName, LastName = @LastName, Specialty = @Specialty, PhoneNumber = @PhoneNumber, Email = @Email, UpdatedAt = GETUTCDATE() WHERE ID = @ID;", new {doctor.FirstName, doctor.LastName, doctor.Specialty, doctor .PhoneNumber, doctor.Email,doctor.ID}).ConfigureAwait(false);


        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Doctors>> GetDoctors()
            => await _con.QueryAsync<Doctors>(@"SELECT [ID]
                                                  ,[FirstName]
                                                  ,[LastName]
                                                  ,[Specialty]
                                                  ,[PhoneNumber]
                                                  ,[Email]
                                                  ,dbo.ufntolocaltime([CreatedAt]) AS [CreatedAt]
                                                  ,dbo.ufntolocaltime([UpdatedAt]) AS [UpdatedAt]
                                              FROM [Medical.Office.SqlLocalDB].[dbo].[Doctors]").ConfigureAwait(false);

        public async Task<Doctors> GetDoctor(long IDDoctor)
            => await _con.QuerySingleAsync<Doctors>(@"SELECT [ID]
                                                      ,[FirstName]
                                                      ,[LastName]
                                                      ,[Specialty]
                                                      ,[PhoneNumber]
                                                      ,[Email]
                                                      ,dbo.ufntolocaltime([CreatedAt]) AS [CreatedAt]
                                                        ,dbo.ufntolocaltime([UpdatedAt]) AS [UpdatedAt]
                                                  FROM [Medical.Office.SqlLocalDB].[dbo].[Doctors] WHERE ID = @IDDoctor", new { IDDoctor }).ConfigureAwait(false);
        
      
        /// <summary>
        ///
        /// </summary>
        /// <param name="IDPatient"></param>
        /// <returns></returns>


        /// <summary>
        ///
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="FathersSurname"></param>
        /// <param name="MothersSurname"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="Gender"></param>
        /// <param name="Address"></param>
        /// <param name="Country"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="ZipCode"></param>
        /// <param name="OutsideNumber"></param>
        /// <param name="InsideNumber"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Email"></param>
        /// <param name="EmergencyContactName"></param>
        /// <param name="EmergencyContactPhone"></param>
        /// <param name="InsuranceProvider"></param>
        /// <param name="PolicyNumber"></param>
        /// <param name="BloodType"></param>
        /// <param name="DateCreated"></param>
        /// <param name="LastUpdated"></param>
        /// <param name="Photo"></param>
        /// <param name="InternalNotes"></param>
        /// <returns></returns>
        public async Task InsertPatientData(string Name, string FathersSurname, string MothersSurname, DateTime? DateOfBirth, string Gender, string Address, string Country, string City, string State, string ZipCode, string OutsideNumber, string InsideNumber, string PhoneNumber, string Email, string EmergencyContactName, string EmergencyContactPhone, string InsuranceProvider, string PolicyNumber, string BloodType, byte[] Photo, string InternalNotes)
            => await _con.ExecuteAsync("INSERT INTO [Medical.Office.SqlLocalDB].[dbo].[PatientData] " +
                "([Name], [FathersSurname], [MothersSurname], [DateOfBirth], [Gender], [Address], [Country], [City], [State], [ZipCode], [OutsideNumber], [InsideNumber], [PhoneNumber], [Email], [EmergencyContactName], [EmergencyContactPhone], [InsuranceProvider], [PolicyNumber], [BloodType], [Photo], [InternalNotes]) " +
                "VALUES(@Name, @FathersSurname, @MothersSurname, @DateOfBirth, @Gender, @Address, @Country, @City, @State, @ZipCode, @OutsideNumber, @InsideNumber, @PhoneNumber, @Email, @EmergencyContactName, @EmergencyContactPhone, @InsuranceProvider, @PolicyNumber, @BloodType, @Photo, @InternalNotes)",
                new{Name,FathersSurname,MothersSurname,DateOfBirth,Gender,Address,Country,City,State,ZipCode,OutsideNumber,InsideNumber,PhoneNumber,Email,
                    EmergencyContactName,EmergencyContactPhone,InsuranceProvider,PolicyNumber,BloodType,Photo,InternalNotes}).ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<PatientData> GetLastPatientsData()
             => await _con.QuerySingleAsync<PatientData>(@"SELECT TOP (1) [ID]
      ,[Name]
      ,[FathersSurname]
      ,[MothersSurname]
      ,[DateOfBirth]
      ,[Gender]
      ,[Address]
      ,[Country]
      ,[City]
      ,[State]
      ,[ZipCode]
      ,[OutsideNumber]
      ,[InsideNumber]
      ,[PhoneNumber]
      ,[Email]
      ,[EmergencyContactName]
      ,[EmergencyContactPhone]
      ,[InsuranceProvider]
      ,[PolicyNumber]
      ,[BloodType]
      ,dbo.ufntolocaltime([DateCreated]) AS [DateCreated]
      ,dbo.ufntolocaltime([LastUpdated]) AS [LastUpdated]
      ,[Photo]
      ,[InternalNotes]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientData] 
  ORDER BY ID DESC").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PatientData>> GetPatientsDataList()
            => await _con.QueryAsync<PatientData>(@"SELECT [ID]
      ,[Name]
      ,[FathersSurname]
      ,[MothersSurname]
      ,[DateOfBirth]
      ,[Gender]
      ,[Address]
      ,[Country]
      ,[City]
      ,[State]
      ,[ZipCode]
      ,[OutsideNumber]
      ,[InsideNumber]
      ,[PhoneNumber]
      ,[Email]
      ,[EmergencyContactName]
      ,[EmergencyContactPhone]
      ,[InsuranceProvider]
      ,[PolicyNumber]
      ,[BloodType]
      ,dbo.ufntolocaltime([DateCreated]) AS [DateCreated]
      ,dbo.ufntolocaltime([LastUpdated]) AS [LastUpdated]
      ,[Photo]
      ,[InternalNotes]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientData]").ConfigureAwait(false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<PatientData> GetPatientDataByIDPatient(long ID)
            => await _con.QuerySingleAsync<PatientData>(@"SELECT [ID]
      ,[Name]
      ,[FathersSurname]
      ,[MothersSurname]
      ,[DateOfBirth]
      ,[Gender]
      ,[Address]
      ,[Country]
      ,[City]
      ,[State]
      ,[ZipCode]
      ,[OutsideNumber]
      ,[InsideNumber]
      ,[PhoneNumber]
      ,[Email]
      ,[EmergencyContactName]
      ,[EmergencyContactPhone]
      ,[InsuranceProvider]
      ,[PolicyNumber]
      ,[BloodType]
      ,dbo.ufntolocaltime([DateCreated]) AS [DateCreated]
      ,dbo.ufntolocaltime([LastUpdated]) AS [LastUpdated]
      ,[Photo]
      ,[InternalNotes]
  FROM [Medical.Office.SqlLocalDB].[dbo].[PatientData] WHERE ID = @ID", new {ID}).ConfigureAwait(false);

        #endregion

        #region AntecedentPatient
      
        #endregion

        #region POS
        // Obtener todos los registros
        public async Task<IEnumerable<CashMovements>> GetCashMovementsAsync()
            => await _con.QueryAsync<CashMovements>("SELECT * FROM CashMovements").ConfigureAwait(false);

        // Obtener un registro por ID
        public async Task<CashMovements> GetCashMovementByIdAsync(CashMovements cashMovements)
            => await _con.QuerySingleAsync<CashMovements>(
                "SELECT * FROM CashMovements WHERE CashMovementId = @CashMovementId",
                new { cashMovements.CashMovementId }).ConfigureAwait(false);

        // Insertar un registro
        public async Task InsertCashMovementAsync(CashMovements cashMovements)
            => await _con.ExecuteAsync(
                @"INSERT INTO CashMovements (CashRegisterId, MovementDate, MovementType, Amount, Description)
                  VALUES (@CashRegisterId, @MovementDate, @MovementType, @Amount, @Description)",
                cashMovements).ConfigureAwait(false);

        // Actualizar un registro
        public async Task UpdateCashMovementAsync(CashMovements cashMovements)
            => await _con.ExecuteAsync(
                @"UPDATE CashMovements
                  SET CashRegisterId = @CashRegisterId,
                      MovementDate = @MovementDate,
                      MovementType = @MovementType,
                      Amount = @Amount,
                      Description = @Description
                  WHERE CashMovementId = @CashMovementId",
                cashMovements).ConfigureAwait(false);

        // Eliminar un registro
        public async Task DeleteCashMovementAsync(CashMovements cashMovements)
            => await _con.ExecuteAsync(
                "DELETE FROM CashMovements WHERE CashMovementId = @CashMovementId",
                new { cashMovements.CashMovementId }).ConfigureAwait(false);

        // Obtener todos los registros
        public async Task<IEnumerable<CashRegisters>> GetCashRegistersAsync()
            => await _con.QueryAsync<CashRegisters>("SELECT * FROM CashRegisters").ConfigureAwait(false);

        // Obtener un registro por ID
        public async Task<CashRegisters> GetCashRegisterByIdAsync(CashRegisters cashRegisters)
            => await _con.QuerySingleAsync<CashRegisters>(
                "SELECT * FROM CashRegisters WHERE CashRegisterId = @CashRegisterId",
                new { cashRegisters.CashRegisterId }).ConfigureAwait(false);

        // Insertar un registro
        public async Task InsertCashRegisterAsync(CashRegisters cashRegisters)
            => await _con.ExecuteAsync(
                @"INSERT INTO CashRegisters (RegisterName, RegisterStatus, OpeningDate, ClosingDate, InitialBalance, FinalBalance)
                  VALUES (@RegisterName, @RegisterStatus, @OpeningDate, @ClosingDate, @InitialBalance, @FinalBalance)",
                cashRegisters).ConfigureAwait(false);

        // Actualizar un registro
        public async Task UpdateCashRegisterAsync(CashRegisters cashRegisters)
            => await _con.ExecuteAsync(
                @"UPDATE CashRegisters
                  SET RegisterName = @RegisterName,
                      RegisterStatus = @RegisterStatus,
                      OpeningDate = @OpeningDate,
                      ClosingDate = @ClosingDate,
                      InitialBalance = @InitialBalance,
                      FinalBalance = @FinalBalance
                  WHERE CashRegisterId = @CashRegisterId",
                cashRegisters).ConfigureAwait(false);

        // Eliminar un registro
        public async Task DeleteCashRegisterAsync(CashRegisters cashRegisters)
            => await _con.ExecuteAsync(
                "DELETE FROM CashRegisters WHERE CashRegisterId = @CashRegisterId",
                new { cashRegisters.CashRegisterId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de InventoryMovements.
        /// </summary>
        /// <returns>Una lista de InventoryMovements.</returns>
        public async Task<IEnumerable<InventoryMovements>> GetInventoryMovementsAsync()
            => await _con.QueryAsync<InventoryMovements>("SELECT * FROM InventoryMovements").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de InventoryMovements por ID.
        /// </summary>
        /// <param name="inventoryMovements">El objeto InventoryMovements con el ID especificado.</param>
        /// <returns>El registro de InventoryMovements encontrado.</returns>
        public async Task<InventoryMovements> GetInventoryMovementByIdAsync(InventoryMovements inventoryMovements)
            => await _con.QuerySingleAsync<InventoryMovements>(
                "SELECT * FROM InventoryMovements WHERE MovementId = @MovementId",
                new { inventoryMovements.MovementId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en InventoryMovements.
        /// </summary>
        /// <param name="inventoryMovements">El objeto InventoryMovements a insertar.</param>
        public async Task InsertInventoryMovementAsync(InventoryMovements inventoryMovements)
            => await _con.ExecuteAsync(
                @"INSERT INTO InventoryMovements (ProductId, MovementType, Quantity, MovementDate, Description)
          VALUES (@ProductId, @MovementType, @Quantity, @MovementDate, @Description)",
                inventoryMovements).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en InventoryMovements.
        /// </summary>
        /// <param name="inventoryMovements">El objeto InventoryMovements con los datos actualizados.</param>
        public async Task UpdateInventoryMovementAsync(InventoryMovements inventoryMovements)
            => await _con.ExecuteAsync(
                @"UPDATE InventoryMovements
          SET ProductId = @ProductId,
              MovementType = @MovementType,
              Quantity = @Quantity,
              MovementDate = @MovementDate,
              Description = @Description
          WHERE MovementId = @MovementId",
                inventoryMovements).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de InventoryMovements por ID.
        /// </summary>
        /// <param name="inventoryMovements">El objeto InventoryMovements con el ID especificado.</param>
        public async Task DeleteInventoryMovementAsync(InventoryMovements inventoryMovements)
            => await _con.ExecuteAsync(
                "DELETE FROM InventoryMovements WHERE MovementId = @MovementId",
                new { inventoryMovements.MovementId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de PaymentTypes.
        /// </summary>
        /// <returns>Una lista de PaymentTypes.</returns>
        public async Task<IEnumerable<PaymentTypes>> GetPaymentTypesAsync()
            => await _con.QueryAsync<PaymentTypes>("SELECT * FROM PaymentTypes").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de PaymentTypes por ID.
        /// </summary>
        /// <param name="paymentTypes">El objeto PaymentTypes con el ID especificado.</param>
        /// <returns>El registro de PaymentTypes encontrado.</returns>
        public async Task<PaymentTypes> GetPaymentTypeByIdAsync(PaymentTypes paymentTypes)
            => await _con.QuerySingleAsync<PaymentTypes>(
                "SELECT * FROM PaymentTypes WHERE Id = @Id",
                new { paymentTypes.Id }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en PaymentTypes.
        /// </summary>
        /// <param name="paymentTypes">El objeto PaymentTypes a insertar.</param>
        public async Task InsertPaymentTypeAsync(PaymentTypes paymentTypes)
            => await _con.ExecuteAsync(
                @"INSERT INTO PaymentTypes (PaymentTypeName)
          VALUES (@PaymentTypeName)",
                paymentTypes).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en PaymentTypes.
        /// </summary>
        /// <param name="paymentTypes">El objeto PaymentTypes con los datos actualizados.</param>
        public async Task UpdatePaymentTypeAsync(PaymentTypes paymentTypes)
            => await _con.ExecuteAsync(
                @"UPDATE PaymentTypes
          SET PaymentTypeName = @PaymentTypeName
          WHERE Id = @Id",
                paymentTypes).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de PaymentTypes por ID.
        /// </summary>
        /// <param name="paymentTypes">El objeto PaymentTypes con el ID especificado.</param>
        public async Task DeletePaymentTypeAsync(PaymentTypes paymentTypes)
            => await _con.ExecuteAsync(
                "DELETE FROM PaymentTypes WHERE Id = @Id",
                new { paymentTypes.Id }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de ProductCategories.
        /// </summary>
        /// <returns>Una lista de ProductCategories.</returns>
        public async Task<IEnumerable<ProductCategories>> GetProductCategoriesAsync()
            => await _con.QueryAsync<ProductCategories>("SELECT * FROM ProductCategories").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de ProductCategories por ID.
        /// </summary>
        /// <param name="productCategories">El objeto ProductCategories con el ID especificado.</param>
        /// <returns>El registro de ProductCategories encontrado.</returns>
        public async Task<ProductCategories> GetProductCategoryByIdAsync(ProductCategories productCategories)
            => await _con.QuerySingleAsync<ProductCategories>(
                "SELECT * FROM ProductCategories WHERE ProductCategoryId = @ProductCategoryId",
                new { productCategories.ProductCategoryId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en ProductCategories.
        /// </summary>
        /// <param name="productCategories">El objeto ProductCategories a insertar.</param>
        public async Task InsertProductCategoryAsync(ProductCategories productCategories)
            => await _con.ExecuteAsync(
                @"INSERT INTO ProductCategories (CategoryName)
          VALUES (@CategoryName)",
                productCategories).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en ProductCategories.
        /// </summary>
        /// <param name="productCategories">El objeto ProductCategories con los datos actualizados.</param>
        public async Task UpdateProductCategoryAsync(ProductCategories productCategories)
            => await _con.ExecuteAsync(
                @"UPDATE ProductCategories
          SET CategoryName = @CategoryName
          WHERE ProductCategoryId = @ProductCategoryId",
                productCategories).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de ProductCategories por ID.
        /// </summary>
        /// <param name="productCategories">El objeto ProductCategories con el ID especificado.</param>
        public async Task DeleteProductCategoryAsync(ProductCategories productCategories)
            => await _con.ExecuteAsync(
                "DELETE FROM ProductCategories WHERE ProductCategoryId = @ProductCategoryId",
                new { productCategories.ProductCategoryId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de Products.
        /// </summary>
        /// <returns>Una lista de Products.</returns>
        public async Task<IEnumerable<Products>> GetProductsAsync()
            => await _con.QueryAsync<Products>("SELECT * FROM Products").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de Products por ID.
        /// </summary>
        /// <param name="products">El objeto Products con el ID especificado.</param>
        /// <returns>El registro de Products encontrado.</returns>
        public async Task<Products> GetProductByIdAsync(Products products)
            => await _con.QuerySingleAsync<Products>(
                "SELECT * FROM Products WHERE ProductId = @ProductId",
                new { products.ProductId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en Products.
        /// </summary>
        /// <param name="products">El objeto Products a insertar.</param>
        public async Task InsertProductAsync(Products products)
            => await _con.ExecuteAsync(
                @"INSERT INTO Products (ProductName, Description, Price, Stock, ProductCategoryName, IDORBarcode)
          VALUES (@ProductName, @Description, @Price, @Stock, @ProductCategoryName, @IDORBarcode)",
                products).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en Products.
        /// </summary>
        /// <param name="products">El objeto Products con los datos actualizados.</param>
        public async Task UpdateProductAsync(Products products)
            => await _con.ExecuteAsync(
                @"UPDATE Products
          SET ProductName = @ProductName,
              Description = @Description,
              Price = @Price,
              Stock = @Stock,
              ProductCategoryName = @ProductCategoryName,
              IDORBarcode = @IDORBarcode
          WHERE ProductId = @ProductId",
                products).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de Products por ID.
        /// </summary>
        /// <param name="products">El objeto Products con el ID especificado.</param>
        public async Task DeleteProductAsync(Products products)
            => await _con.ExecuteAsync(
                "DELETE FROM Products WHERE ProductId = @ProductId",
                new { products.ProductId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de Promotions.
        /// </summary>
        /// <returns>Una lista de Promotions.</returns>
        public async Task<IEnumerable<Promotions>> GetPromotionsAsync()
            => await _con.QueryAsync<Promotions>("SELECT * FROM Promotions").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de Promotions por ID.
        /// </summary>
        /// <param name="promotions">El objeto Promotions con el ID especificado.</param>
        /// <returns>El registro de Promotions encontrado.</returns>
        public async Task<Promotions> GetPromotionByIdAsync(Promotions promotions)
            => await _con.QuerySingleAsync<Promotions>(
                "SELECT * FROM Promotions WHERE PromotionId = @PromotionId",
                new { promotions.PromotionId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en Promotions.
        /// </summary>
        /// <param name="promotions">El objeto Promotions a insertar.</param>
        public async Task InsertPromotionAsync(Promotions promotions)
            => await _con.ExecuteAsync(
                @"INSERT INTO Promotions (PromotionName, Description, StartDate, EndDate, PromotionType, Value)
          VALUES (@PromotionName, @Description, @StartDate, @EndDate, @PromotionType, @Value)",
                promotions).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en Promotions.
        /// </summary>
        /// <param name="promotions">El objeto Promotions con los datos actualizados.</param>
        public async Task UpdatePromotionAsync(Promotions promotions)
            => await _con.ExecuteAsync(
                @"UPDATE Promotions
          SET PromotionName = @PromotionName,
              Description = @Description,
              StartDate = @StartDate,
              EndDate = @EndDate,
              PromotionType = @PromotionType,
              Value = @Value
          WHERE PromotionId = @PromotionId",
                promotions).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de Promotions por ID.
        /// </summary>
        /// <param name="promotions">El objeto Promotions con el ID especificado.</param>
        public async Task DeletePromotionAsync(Promotions promotions)
            => await _con.ExecuteAsync(
                "DELETE FROM Promotions WHERE PromotionId = @PromotionId",
                new { promotions.PromotionId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de ReturnDetails.
        /// </summary>
        /// <returns>Una lista de ReturnDetails.</returns>
        public async Task<IEnumerable<ReturnDetails>> GetReturnDetailsAsync()
            => await _con.QueryAsync<ReturnDetails>("SELECT * FROM ReturnDetails").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de ReturnDetails por ID.
        /// </summary>
        /// <param name="returnDetails">El objeto ReturnDetails con el ID especificado.</param>
        /// <returns>El registro de ReturnDetails encontrado.</returns>
        public async Task<ReturnDetails> GetReturnDetailByIdAsync(ReturnDetails returnDetails)
            => await _con.QuerySingleAsync<ReturnDetails>(
                "SELECT * FROM ReturnDetails WHERE ReturnDetailId = @ReturnDetailId",
                new { returnDetails.ReturnDetailId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en ReturnDetails.
        /// </summary>
        /// <param name="returnDetails">El objeto ReturnDetails a insertar.</param>
        public async Task InsertReturnDetailAsync(ReturnDetails returnDetails)
            => await _con.ExecuteAsync(
                @"INSERT INTO ReturnDetails (ReturnId, ProductId, Quantity, UnitPrice, Subtotal)
          VALUES (@ReturnId, @ProductId, @Quantity, @UnitPrice, @Subtotal)",
                returnDetails).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en ReturnDetails.
        /// </summary>
        /// <param name="returnDetails">El objeto ReturnDetails con los datos actualizados.</param>
        public async Task UpdateReturnDetailAsync(ReturnDetails returnDetails)
            => await _con.ExecuteAsync(
                @"UPDATE ReturnDetails
          SET ReturnId = @ReturnId,
              ProductId = @ProductId,
              Quantity = @Quantity,
              UnitPrice = @UnitPrice,
              Subtotal = @Subtotal
          WHERE ReturnDetailId = @ReturnDetailId",
                returnDetails).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de ReturnDetails por ID.
        /// </summary>
        /// <param name="returnDetails">El objeto ReturnDetails con el ID especificado.</param>
        public async Task DeleteReturnDetailAsync(ReturnDetails returnDetails)
            => await _con.ExecuteAsync(
                "DELETE FROM ReturnDetails WHERE ReturnDetailId = @ReturnDetailId",
                new { returnDetails.ReturnDetailId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de ReturnsProducts.
        /// </summary>
        /// <returns>Una lista de ReturnsProducts.</returns>
        public async Task<IEnumerable<ReturnsProducts>> GetReturnsProductsAsync()
            => await _con.QueryAsync<ReturnsProducts>("SELECT * FROM ReturnsProducts").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de ReturnsProducts por ID.
        /// </summary>
        /// <param name="returnsProducts">El objeto ReturnsProducts con el ID especificado.</param>
        /// <returns>El registro de ReturnsProducts encontrado.</returns>
        public async Task<ReturnsProducts> GetReturnProductByIdAsync(ReturnsProducts returnsProducts)
            => await _con.QuerySingleAsync<ReturnsProducts>(
                "SELECT * FROM ReturnsProducts WHERE ReturnId = @ReturnId",
                new { returnsProducts.ReturnId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en ReturnsProducts.
        /// </summary>
        /// <param name="returnsProducts">El objeto ReturnsProducts a insertar.</param>
        public async Task InsertReturnProductAsync(ReturnsProducts returnsProducts)
            => await _con.ExecuteAsync(
                @"INSERT INTO ReturnsProducts (SaleId, ReturnDate, RefundedAmount, ReturnStatusName)
          VALUES (@SaleId, @ReturnDate, @RefundedAmount, @ReturnStatusName)",
                returnsProducts).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en ReturnsProducts.
        /// </summary>
        /// <param name="returnsProducts">El objeto ReturnsProducts con los datos actualizados.</param>
        public async Task UpdateReturnProductAsync(ReturnsProducts returnsProducts)
            => await _con.ExecuteAsync(
                @"UPDATE ReturnsProducts
          SET SaleId = @SaleId,
              ReturnDate = @ReturnDate,
              RefundedAmount = @RefundedAmount,
              ReturnStatusName = @ReturnStatusName
          WHERE ReturnId = @ReturnId",
                returnsProducts).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de ReturnsProducts por ID.
        /// </summary>
        /// <param name="returnsProducts">El objeto ReturnsProducts con el ID especificado.</param>
        public async Task DeleteReturnProductAsync(ReturnsProducts returnsProducts)
            => await _con.ExecuteAsync(
                "DELETE FROM ReturnsProducts WHERE ReturnId = @ReturnId",
                new { returnsProducts.ReturnId }).ConfigureAwait(false);

        /// <summary>
        /// Obtiene todos los registros de ReturnStatuses.
        /// </summary>
        /// <returns>Una lista de ReturnStatuses.</returns>
        public async Task<IEnumerable<ReturnStatuses>> GetReturnStatusesAsync()
            => await _con.QueryAsync<ReturnStatuses>("SELECT * FROM ReturnStatuses").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de ReturnStatuses por ID.
        /// </summary>
        /// <param name="returnStatuses">El objeto ReturnStatuses con el ID especificado.</param>
        /// <returns>El registro de ReturnStatuses encontrado.</returns>
        public async Task<ReturnStatuses> GetReturnStatusByIdAsync(ReturnStatuses returnStatuses)
            => await _con.QuerySingleAsync<ReturnStatuses>(
                "SELECT * FROM ReturnStatuses WHERE ReturnStatusId = @ReturnStatusId",
                new { returnStatuses.ReturnStatusId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en ReturnStatuses.
        /// </summary>
        /// <param name="returnStatuses">El objeto ReturnStatuses a insertar.</param>
        public async Task InsertReturnStatusAsync(ReturnStatuses returnStatuses)
            => await _con.ExecuteAsync(
                @"INSERT INTO ReturnStatuses (StatusName)
          VALUES (@StatusName)",
                returnStatuses).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en ReturnStatuses.
        /// </summary>
        /// <param name="returnStatuses">El objeto ReturnStatuses con los datos actualizados.</param>
        public async Task UpdateReturnStatusAsync(ReturnStatuses returnStatuses)
            => await _con.ExecuteAsync(
                @"UPDATE ReturnStatuses
          SET StatusName = @StatusName
          WHERE ReturnStatusId = @ReturnStatusId",
                returnStatuses).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de ReturnStatuses por ID.
        /// </summary>
        /// <param name="returnStatuses">El objeto ReturnStatuses con el ID especificado.</param>
        public async Task DeleteReturnStatusAsync(ReturnStatuses returnStatuses)
            => await _con.ExecuteAsync(
                "DELETE FROM ReturnStatuses WHERE ReturnStatusId = @ReturnStatusId",
                new { returnStatuses.ReturnStatusId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de SaleDetails.
        /// </summary>
        /// <returns>Una lista de SaleDetails.</returns>
        public async Task<IEnumerable<SaleDetails>> GetSaleDetailsAsync()
            => await _con.QueryAsync<SaleDetails>("SELECT * FROM SaleDetails").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de SaleDetails por ID.
        /// </summary>
        /// <param name="saleDetails">El objeto SaleDetails con el ID especificado.</param>
        /// <returns>El registro de SaleDetails encontrado.</returns>
        public async Task<SaleDetails> GetSaleDetailByIdAsync(SaleDetails saleDetails)
            => await _con.QuerySingleAsync<SaleDetails>(
                "SELECT * FROM SaleDetails WHERE SaleDetailId = @SaleDetailId",
                new { saleDetails.SaleDetailId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en SaleDetails.
        /// </summary>
        /// <param name="saleDetails">El objeto SaleDetails a insertar.</param>
        public async Task InsertSaleDetailAsync(SaleDetails saleDetails)
            => await _con.ExecuteAsync(
                @"INSERT INTO SaleDetails (SaleId, ProductId, Quantity, UnitPrice, Subtotal)
          VALUES (@SaleId, @ProductId, @Quantity, @UnitPrice, @Subtotal)",
                saleDetails).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en SaleDetails.
        /// </summary>
        /// <param name="saleDetails">El objeto SaleDetails con los datos actualizados.</param>
        public async Task UpdateSaleDetailAsync(SaleDetails saleDetails)
            => await _con.ExecuteAsync(
                @"UPDATE SaleDetails
          SET SaleId = @SaleId,
              ProductId = @ProductId,
              Quantity = @Quantity,
              UnitPrice = @UnitPrice,
              Subtotal = @Subtotal
          WHERE SaleDetailId = @SaleDetailId",
                saleDetails).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de SaleDetails por ID.
        /// </summary>
        /// <param name="saleDetails">El objeto SaleDetails con el ID especificado.</param>
        public async Task DeleteSaleDetailAsync(SaleDetails saleDetails)
            => await _con.ExecuteAsync(
                "DELETE FROM SaleDetails WHERE SaleDetailId = @SaleDetailId",
                new { saleDetails.SaleDetailId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de Sales.
        /// </summary>
        /// <returns>Una lista de Sales.</returns>
        public async Task<IEnumerable<Sales>> GetSalesAsync()
            => await _con.QueryAsync<Sales>("SELECT * FROM Sales").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de Sales por ID.
        /// </summary>
        /// <param name="sales">El objeto Sales con el ID especificado.</param>
        /// <returns>El registro de Sales encontrado.</returns>
        public async Task<Sales> GetSaleByIdAsync(Sales sales)
            => await _con.QuerySingleAsync<Sales>(
                "SELECT * FROM Sales WHERE SaleId = @SaleId",
                new { sales.SaleId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en Sales.
        /// </summary>
        /// <param name="sales">El objeto Sales a insertar.</param>
        public async Task InsertSaleAsync(Sales sales)
            => await _con.ExecuteAsync(
                @"INSERT INTO Sales (IDPatient, SaleDate, TotalAmount, PaymentType, SaleStatus, UserId)
          VALUES (@IDPatient, @SaleDate, @TotalAmount, @PaymentType, @SaleStatus, @UserId)",
                sales).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en Sales.
        /// </summary>
        /// <param name="sales">El objeto Sales con los datos actualizados.</param>
        public async Task UpdateSaleAsync(Sales sales)
            => await _con.ExecuteAsync(
                @"UPDATE Sales
          SET IDPatient = @IDPatient,
              SaleDate = @SaleDate,
              TotalAmount = @TotalAmount,
              PaymentType = @PaymentType,
              SaleStatus = @SaleStatus,
              UserId = @UserId
          WHERE SaleId = @SaleId",
                sales).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de Sales por ID.
        /// </summary>
        /// <param name="sales">El objeto Sales con el ID especificado.</param>
        public async Task DeleteSaleAsync(Sales sales)
            => await _con.ExecuteAsync(
                "DELETE FROM Sales WHERE SaleId = @SaleId",
                new { sales.SaleId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de SalesPromotions.
        /// </summary>
        /// <returns>Una lista de SalesPromotions.</returns>
        public async Task<IEnumerable<SalesPromotions>> GetSalesPromotionsAsync()
            => await _con.QueryAsync<SalesPromotions>("SELECT * FROM SalesPromotions").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de SalesPromotions por ID.
        /// </summary>
        /// <param name="salesPromotions">El objeto SalesPromotions con el ID especificado.</param>
        /// <returns>El registro de SalesPromotions encontrado.</returns>
        public async Task<SalesPromotions> GetSalesPromotionByIdAsync(SalesPromotions salesPromotions)
            => await _con.QuerySingleAsync<SalesPromotions>(
                "SELECT * FROM SalesPromotions WHERE SalePromotionId = @SalePromotionId",
                new { salesPromotions.SalePromotionId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en SalesPromotions.
        /// </summary>
        /// <param name="salesPromotions">El objeto SalesPromotions a insertar.</param>
        public async Task InsertSalesPromotionAsync(SalesPromotions salesPromotions)
            => await _con.ExecuteAsync(
                @"INSERT INTO SalesPromotions (SaleId, PromotionId, DiscountApplied)
          VALUES (@SaleId, @PromotionId, @DiscountApplied)",
                salesPromotions).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en SalesPromotions.
        /// </summary>
        /// <param name="salesPromotions">El objeto SalesPromotions con los datos actualizados.</param>
        public async Task UpdateSalesPromotionAsync(SalesPromotions salesPromotions)
            => await _con.ExecuteAsync(
                @"UPDATE SalesPromotions
          SET SaleId = @SaleId,
              PromotionId = @PromotionId,
              DiscountApplied = @DiscountApplied
          WHERE SalePromotionId = @SalePromotionId",
                salesPromotions).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de SalesPromotions por ID.
        /// </summary>
        /// <param name="salesPromotions">El objeto SalesPromotions con el ID especificado.</param>
        public async Task DeleteSalesPromotionAsync(SalesPromotions salesPromotions)
            => await _con.ExecuteAsync(
                "DELETE FROM SalesPromotions WHERE SalePromotionId = @SalePromotionId",
                new { salesPromotions.SalePromotionId }).ConfigureAwait(false);


        /// <summary>
        /// Obtiene todos los registros de SaleStatuses.
        /// </summary>
        /// <returns>Una lista de SaleStatuses.</returns>
        public async Task<IEnumerable<SaleStatuses>> GetSaleStatusesAsync()
            => await _con.QueryAsync<SaleStatuses>("SELECT * FROM SaleStatuses").ConfigureAwait(false);

        /// <summary>
        /// Obtiene un registro de SaleStatuses por ID.
        /// </summary>
        /// <param name="saleStatuses">El objeto SaleStatuses con el ID especificado.</param>
        /// <returns>El registro de SaleStatuses encontrado.</returns>
        public async Task<SaleStatuses> GetSaleStatusByIdAsync(SaleStatuses saleStatuses)
            => await _con.QuerySingleAsync<SaleStatuses>(
                "SELECT * FROM SaleStatuses WHERE SaleStatusId = @SaleStatusId",
                new { saleStatuses.SaleStatusId }).ConfigureAwait(false);

        /// <summary>
        /// Inserta un nuevo registro en SaleStatuses.
        /// </summary>
        /// <param name="saleStatuses">El objeto SaleStatuses a insertar.</param>
        public async Task InsertSaleStatusAsync(SaleStatuses saleStatuses)
            => await _con.ExecuteAsync(
                @"INSERT INTO SaleStatuses (StatusName)
          VALUES (@StatusName)",
                saleStatuses).ConfigureAwait(false);

        /// <summary>
        /// Actualiza un registro existente en SaleStatuses.
        /// </summary>
        /// <param name="saleStatuses">El objeto SaleStatuses con los datos actualizados.</param>
        public async Task UpdateSaleStatusAsync(SaleStatuses saleStatuses)
            => await _con.ExecuteAsync(
                @"UPDATE SaleStatuses
          SET StatusName = @StatusName
          WHERE SaleStatusId = @SaleStatusId",
                saleStatuses).ConfigureAwait(false);

        /// <summary>
        /// Elimina un registro de SaleStatuses por ID.
        /// </summary>
        /// <param name="saleStatuses">El objeto SaleStatuses con el ID especificado.</param>
        public async Task DeleteSaleStatusAsync(SaleStatuses saleStatuses)
            => await _con.ExecuteAsync(
                "DELETE FROM SaleStatuses WHERE SaleStatusId = @SaleStatusId",
                new { saleStatuses.SaleStatusId }).ConfigureAwait(false);

        #endregion
        
    }
}
