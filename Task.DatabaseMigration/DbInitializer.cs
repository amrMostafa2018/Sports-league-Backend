using TVTC.GDPT.Shared.Model.Entities.Lookup;
using TVTC.GDPT.Shared.Model.Entities.EServices;
using System.Linq;
using System.Collections.Generic;
using TVTC.GDPT.Shared.Model.Entities.CMS;
using System;
using System.Globalization;

namespace TVTC.GDPT.DatabaseMigration
{

    public static class DbInitializer
    {

        public static void Initialize(GDPTDbContext context)
        {
            if (!context.ShiftTypes.Any(a => a.NameAr == "فترة واحدة"))
                context.ShiftTypes.Add(new ShiftType
                {
                    Id = 1,
                    NameAr = "فترة واحدة",
                    IsVisible = true
                });

            if (!context.ShiftTypes.Any(a => a.NameAr == "صباحي / مسائي"))
                context.ShiftTypes.Add(new ShiftType
                {
                    Id = 2,
                    NameAr = "صباحي / مسائي",
                    IsVisible = true
                });

            if (!context.ShiftTypes.Any(a => a.NameAr == "صباحي"))
                context.ShiftTypes.Add(new ShiftType
                {
                    Id = 3,
                    NameAr = "صباحي",
                    IsVisible = true
                });

            if (!context.ShiftTypes.Any(a => a.NameAr == "مسائي"))
                context.ShiftTypes.Add(new ShiftType
                {
                    Id = 4,
                    NameAr = "مسائي",
                    IsVisible = true
                });

            context.SaveChanges();

            if (!context.InstitutionWorkingTimeTypes.Any(a => a.NameAr == "عام"))
                context.InstitutionWorkingTimeTypes.Add(new InstitutionWorkingTimeType
                {
                    Id = 1,
                    NameAr = "عام",
                    IsVisible = true
                });

            if (!context.InstitutionWorkingTimeTypes.Any(a => a.NameAr == "خلال رمضان"))
                context.InstitutionWorkingTimeTypes.Add(new InstitutionWorkingTimeType
                {
                    Id = 2,
                    NameAr = "خلال رمضان",
                    IsVisible = true
                });

            if (!context.InstitutionWorkingTimeTypes.Any(a => a.NameAr == "خلال الإجازات"))
                context.InstitutionWorkingTimeTypes.Add(new InstitutionWorkingTimeType
                {
                    Id = 3,
                    NameAr = "خلال الإجازات",
                    IsVisible = true
                });

            context.SaveChanges();

            if (!context.EquipmentFieldTypes.Any(a => a.Name == EquipmentFieldTypeEnum.Number.ToString()))
                context.EquipmentFieldTypes.Add(new EquipmentFieldType
                {
                    Id = (int)EquipmentFieldTypeEnum.Number,
                    Name = EquipmentFieldTypeEnum.Number.ToString()
                });
            if (!context.EquipmentFieldTypes.Any(a => a.Name == EquipmentFieldTypeEnum.YesNo.ToString()))
                context.EquipmentFieldTypes.Add(new EquipmentFieldType
                {
                    Id = (int)EquipmentFieldTypeEnum.YesNo,
                    Name = EquipmentFieldTypeEnum.YesNo.ToString()
                });

            if (!context.EquipmentFieldTypes.Any(a => a.Name == EquipmentFieldTypeEnum.SingleLineText.ToString()))
                context.EquipmentFieldTypes.Add(new EquipmentFieldType
                {
                    Id = (int)EquipmentFieldTypeEnum.SingleLineText,
                    Name = EquipmentFieldTypeEnum.SingleLineText.ToString()
                });
            if (!context.EquipmentFieldTypes.Any(a => a.Name == EquipmentFieldTypeEnum.PhoneNumber.ToString()))
                context.EquipmentFieldTypes.Add(new EquipmentFieldType
                {
                    Id = (int)EquipmentFieldTypeEnum.PhoneNumber,
                    Name = EquipmentFieldTypeEnum.PhoneNumber.ToString()
                });

            //Equipment categories
            if (!context.EquipmentTypeCategories.Any(a => a.NameAr == EquipmentTypeCategoryEnum.Category1.ToString()))
                context.EquipmentTypeCategories.Add(new EquipmentTypeCategory
                {
                    // Id = (int)EquipmentTypeCategoryEnum.Category1,
                    NameAr = EquipmentTypeCategoryEnum.Category1.ToString(),
                    IsVisible = true
                });
            if (!context.EquipmentTypeCategories.Any(a => a.NameAr == EquipmentTypeCategoryEnum.Category2.ToString()))
                context.EquipmentTypeCategories.Add(new EquipmentTypeCategory
                {
                    // Id = (int)EquipmentTypeCategoryEnum.Category2,
                    NameAr = EquipmentTypeCategoryEnum.Category2.ToString(),
                    IsVisible = true
                });

            context.SaveChanges();

            //Equipment types -> Shared
            int category1 = context.EquipmentTypeCategories.FirstOrDefault(a => a.NameAr == EquipmentTypeCategoryEnum.Category1.ToString()).Id;
            int category2 = context.EquipmentTypeCategories.FirstOrDefault(a => a.NameAr == EquipmentTypeCategoryEnum.Category2.ToString()).Id;


            AddEquipmentType(context, EquipmentTypeEnum.LandLineNumber, "رقم الهاتف الثابت", EquipmentFieldTypeEnum.PhoneNumber, true, null, null, false, 1, false, null, null, true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.FaxNumber, "الفاكس", EquipmentFieldTypeEnum.PhoneNumber, true, null, null, false, 2, false, null, null, true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.HasInternet, "هل يوجد خدمة انترنت ؟", EquipmentFieldTypeEnum.YesNo, true, true.ToString().ToLower(), null, false, 3, false, null, null, true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.EquipmentsFollowCopyRights, "هل كل التجهيزات والبرامج تخضع لحقوق الملكية الفكرية؟", EquipmentFieldTypeEnum.YesNo, true, true.ToString().ToLower(), null, false, 4, false, null, null, true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.WindowsHaveBlind, "هل يوجد ساتر للنوافذ تحقق الخصوصية ؟", EquipmentFieldTypeEnum.YesNo, true, true.ToString().ToLower(), null, false, 5, false, "تراعي شروط السلامة والإضاءة والتهوية", null, true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.HasExternalBoard, "هل يوجد لوحة خارجية ؟", EquipmentFieldTypeEnum.YesNo, true, true.ToString().ToLower(), null, false, 6, false, @"اللوحة الداخلية والخارجية يجب أن تتضمن إسم المنشأة وعبارة :تحت إشراف المؤسسة العامة للتدريب التقني والمهني", null, true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.HasInternalBoard, "هل يوجد لوحة داخلية على باب المنشأة ؟", EquipmentFieldTypeEnum.YesNo, true, true.ToString().ToLower(), null, false, 7, false, @"اللوحة الداخلية والخارجية يجب أن تتضمن إسم المنشأة وعبارة :تحت إشراف المؤسسة العامة للتدريب التقني والمهني", null, true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.AllHallsHaveAC, "هل كل القاعات والمعامل والمكاتب مكيفة ؟", EquipmentFieldTypeEnum.YesNo, true, true.ToString().ToLower(), null, false, 8, false, null, null, true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.HasMosque, "هل يوجد مصلي", EquipmentFieldTypeEnum.YesNo, true, true.ToString().ToLower(), null, false, 9, false, null, null, false, category1);
            AddEquipmentType(context, EquipmentTypeEnum.DistanceToNearestMosque, "كم يبعد أقرب مسجد", EquipmentFieldTypeEnum.Number, true, "201", null, false, 11, false, null, "متر", true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.AppluationExist, "هل يوجد مغاسل للوضوء؟", EquipmentFieldTypeEnum.YesNo, true, null, null, false, 12, false, null, null, true, category1);

            AddEquipmentType(context, EquipmentTypeEnum.TrainingHallsCount, "عدد قاعات التدريب النظري", EquipmentFieldTypeEnum.Number, true, "1", null, true, 3, true, null, null, true, 1, 1, category2);
            AddEquipmentType(context, EquipmentTypeEnum.LabsCount, "عدد معامل التدريب", EquipmentFieldTypeEnum.Number, true, "1", null, true, 4, false, null, null, true, 1, 2, category2);

            //Equipment types => Center

            AddEquipmentType(context, EquipmentTypeEnum.MosqueArea, "مساحة المصلى", EquipmentFieldTypeEnum.Number, false, "15", InstitutionTypeEnum.Center, true, 10, false, null, "متر مربع", false, 3, 8, category1);
            AddEquipmentType(context, EquipmentTypeEnum.ToiletsCount, "عدد دورات المياه", EquipmentFieldTypeEnum.Number, false, "2", InstitutionTypeEnum.Center, false, 13, false, null, null, true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.ReceptionAndTraineesOfficeArea, "مساحة مكتب استقبال واستراحة المتدربين", EquipmentFieldTypeEnum.Number, false, "20", InstitutionTypeEnum.Center, true, 1, false, null, "متر مربع", true, 3, 7, category2);
            AddEquipmentType(context, EquipmentTypeEnum.ManagmentOfficeArea, "مساحة مكتب الإدارة", EquipmentFieldTypeEnum.Number, false, "15", InstitutionTypeEnum.Center, true, 2, false, null, "متر مربع", true, 2, 3, category2);


            //Equipment types => Institute
            AddEquipmentType(context, EquipmentTypeEnum.InstituteMosqueArea, "مساحة المصلى", EquipmentFieldTypeEnum.Number, false, "15", InstitutionTypeEnum.Institute, true, 10, false, null, "متر مربع", false, 3, 8, category1);
            AddEquipmentType(context, EquipmentTypeEnum.InstituteToiletsCount, "عدد دورات المياه", EquipmentFieldTypeEnum.Number, false, "3", InstitutionTypeEnum.Institute, false, 13, false, null, null, true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.ReceptionOfficeArea, "مساحة صالة / مكتب الاستقبال", EquipmentFieldTypeEnum.Number, false, "20", InstitutionTypeEnum.Institute, true, 1, false, null, "متر مربع", true, 3, 9, category2);
            AddEquipmentType(context, EquipmentTypeEnum.ManagerOfficeArea, "مساحة مكتب المدير", EquipmentFieldTypeEnum.Number, false, "15", InstitutionTypeEnum.Institute, true, 2, false, null, "متر مربع", true, 2, 4, category2);
            AddEquipmentType(context, EquipmentTypeEnum.TrainersOfficesCount, "عدد مكاتب المدربين", EquipmentFieldTypeEnum.Number, false, "1", InstitutionTypeEnum.Institute, true, 4, false, null, null, true, 2, 5, category2);
            AddEquipmentType(context, EquipmentTypeEnum.TraineesRestArea, "مساحة إستراحة المتدربين", EquipmentFieldTypeEnum.Number, false, "20", InstitutionTypeEnum.Institute, true, 5, false, null, "متر مربع", true, 3, 7, category2);


            //Equipment types => High Institute
            AddEquipmentType(context, EquipmentTypeEnum.HighInstituteMosqueArea, "مساحة المصلى", EquipmentFieldTypeEnum.Number, false, "20", InstitutionTypeEnum.HighInstitute, false, 10, true, null, "متر مربع", false, 3, 8, category1);
            AddEquipmentType(context, EquipmentTypeEnum.HighInstituteInstituteToiletsCount, "عدد دورات المياه", EquipmentFieldTypeEnum.Number, false, "3", InstitutionTypeEnum.HighInstitute, false, 13, false, null, null, true, category1);
            AddEquipmentType(context, EquipmentTypeEnum.HighInstituteReceptionOfficeArea, "مساحة صالة / مكتب الاستقبال", EquipmentFieldTypeEnum.Number, false, "20", InstitutionTypeEnum.HighInstitute, true, 1, false, null, "متر مربع", true, 3, 9, category2);
            AddEquipmentType(context, EquipmentTypeEnum.HighInstituteManagerOfficeArea, "مساحة مكتب المدير", EquipmentFieldTypeEnum.Number, false, "15", InstitutionTypeEnum.HighInstitute, true, 2, false, null, "متر مربع", true, 2, 4, category2);
            AddEquipmentType(context, EquipmentTypeEnum.AdministrationOfficesCount, "عدد المكاتب الإدارية", EquipmentFieldTypeEnum.Number, false, "1", InstitutionTypeEnum.HighInstitute, true, 4, false, null, null, true, 2, 3, category2);
            AddEquipmentType(context, EquipmentTypeEnum.SupervisorfficesCount, "عدد مكاتب المشرفين", EquipmentFieldTypeEnum.Number, false, "1", InstitutionTypeEnum.HighInstitute, true, 5, false, null, null, true, 2, 3, category2);
            AddEquipmentType(context, EquipmentTypeEnum.HighInstituteTrainersOfficesCount, "عدد مكاتب المدربين", EquipmentFieldTypeEnum.Number, false, "1", InstitutionTypeEnum.HighInstitute, true, 6, false, null, null, true, 2, 5, category2);
            AddEquipmentType(context, EquipmentTypeEnum.HighInstituteTraineesRestArea, "مساحة إستراحة المتدربين", EquipmentFieldTypeEnum.Number, false, "30", InstitutionTypeEnum.HighInstitute, true, 7, false, null, "متر مربع", true, 3, 7, category2);
            AddEquipmentType(context, EquipmentTypeEnum.HasLibrary, "هل توجد مكتبة", EquipmentFieldTypeEnum.YesNo, true, true.ToString().ToLower(), null, false, 8, false, null, null, false, category2);

            context.SaveChanges();

            //context.Database.EnsureCreated();//if db is not exist ,it will create database .but ,do nothing .
            if (!context.Countries.Any(a => a.NameAr == "السعودية"))
                context.Countries.AddRange(new Country() { Id = 1, NameAr = "السعودية", IsVisible = true, IsDeleted = false, IsGulf = true, Code = "SA" });
            if (!context.Countries.Any(a => a.NameAr == "الامارات"))
                context.Countries.AddRange(new Country() { Id = 2, NameAr = "الامارات", IsVisible = true, IsDeleted = false, Code = "ARE" });
            if (!context.Countries.Any(a => a.NameAr == "الكويت"))
                context.Countries.AddRange(new Country() { Id = 3, NameAr = "الكويت", IsVisible = true, IsDeleted = false, IsGulf = true, Code = "KU" });
            if (!context.Countries.Any(a => a.NameAr == "البحرين"))
                context.Countries.AddRange(new Country() { Id = 4, NameAr = "البحرين", IsVisible = true, IsDeleted = false, Code = "BH" });
            if (!context.Countries.Any(a => a.NameAr == "عمان"))
                context.Countries.AddRange(new Country() { Id = 5, NameAr = "عمان", IsVisible = true, IsDeleted = false, Code = "OM" });
            if (!context.Countries.Any(a => a.NameAr == "قطر"))
                context.Countries.AddRange(new Country() { Id = 6, NameAr = "قطر", IsVisible = true, IsDeleted = false, Code = "QA" });

            if (!context.Nationalities.Any(a => a.NameAr == "السعودية"))
                context.Nationalities.AddRange(new Nationality() { Id = 1, NameAr = "السعودية", IsVisible = true, IsDeleted = false, Code = "SA" });
            if (!context.Nationalities.Any(a => a.NameAr == "الامارات"))
                context.Nationalities.AddRange(new Nationality() { Id = 2, NameAr = "الامارات", IsVisible = true, IsDeleted = false, Code = "ARE" });
            if (!context.Nationalities.Any(a => a.NameAr == "الكويت"))
                context.Nationalities.AddRange(new Nationality() { Id = 3, NameAr = "الكويت", IsVisible = true, IsDeleted = false, Code = "KU" });
            if (!context.Nationalities.Any(a => a.NameAr == "البحرين"))
                context.Nationalities.AddRange(new Nationality() { Id = 4, NameAr = "البحرين", IsVisible = true, IsDeleted = false, Code = "BH" });
            if (!context.Nationalities.Any(a => a.NameAr == "عمان"))
                context.Nationalities.AddRange(new Nationality() { Id = 5, NameAr = "عمان", IsVisible = true, IsDeleted = false, Code = "OM" });
            if (!context.Nationalities.Any(a => a.NameAr == "قطر"))
                context.Nationalities.AddRange(new Nationality() { Id = 6, NameAr = "قطر", IsVisible = true, IsDeleted = false, Code = "QA" });

            if (!context.Cities.Any(a => a.NameAr == "Riyadh"))
                context.Cities.AddRange(new City() { Id = 1, NameAr = "Riyadh", IsVisible = true, IsDeleted = false, DistrictId = 1 });
            if (!context.Cities.Any(a => a.NameAr == "Makkah"))
                context.Cities.AddRange(new City() { Id = 2, NameAr = "Makkah", IsVisible = true, IsDeleted = false, DistrictId = 1 });
            if (!context.Cities.Any(a => a.NameAr == "Jeddah"))
                context.Cities.AddRange(new City() { Id = 3, NameAr = "Jeddah", IsVisible = true, IsDeleted = false, DistrictId = 1 });
            if (!context.Cities.Any(a => a.NameAr == "Madinah"))
                context.Cities.AddRange(new City() { Id = 4, NameAr = "Madinah", IsVisible = true, IsDeleted = false, DistrictId = 1 });

            if (!context.IdentifcationDocumentTypes.Any(a => a.NameAr == "هوية"))
                context.IdentifcationDocumentTypes.Add(new IdentifcationDocumentType() { Id = 1, NameAr = "هوية", IsVisible = true, IsDeleted = false, Key = "ID" });
            if (!context.IdentifcationDocumentTypes.Any(a => a.NameAr == "اقامة"))
                context.IdentifcationDocumentTypes.Add(new IdentifcationDocumentType() { Id = 2, NameAr = "اقامة", IsVisible = true, IsDeleted = false, Key = "Residence" });
            if (!context.IdentifcationDocumentTypes.Any(a => a.NameAr == "جواز سفر"))
                context.IdentifcationDocumentTypes.Add(new IdentifcationDocumentType() { Id = 3, NameAr = "جواز سفر", IsVisible = true, IsDeleted = false, Key = "Passport" });

            if (!context.Qualifications.Any(a => a.NameAr == "CS"))
                context.Qualifications.Add(new Qualification() { Id = 1, NameAr = "CS", IsVisible = true, IsDeleted = false });
            if (!context.Qualifications.Any(a => a.NameAr == "IT"))
                context.Qualifications.Add(new Qualification() { Id = 2, NameAr = "IT", IsVisible = true, IsDeleted = false });

            if (!context.AttachmentTypes.Any(a => a.NameAr == "Commercial Rec"))
                context.AttachmentTypes.Add(new AttachmentType() { Id = 1, NameAr = "Commercial Rec", IsDeleted = false, IsVisible = true, UniqueKey = "CR" });
            if (!context.AttachmentTypes.Any(a => a.NameAr == "ID"))
                context.AttachmentTypes.Add(new AttachmentType() { Id = 2, NameAr = "ID", IsDeleted = false, IsVisible = true, UniqueKey = "ID" });
            if (!context.AttachmentTypes.Any(a => a.NameAr == "Graduation Cert"))
                context.AttachmentTypes.Add(new AttachmentType() { Id = 3, NameAr = "Graduation Cert", IsDeleted = false, IsVisible = true, UniqueKey = "GC" });

            if (!context.ServiceCategories.Any(a => a.NameAr == "Licenses" || a.NameEn == "Licenses"))
                context.ServiceCategories.Add(new ServiceCategory() { Id = 1, NameAr = "الرخص", NameEn = "Licenses", IsDeleted = false, IsVisible = true });
            if (!context.ServiceCategories.Any(a => a.NameAr == "Trainging" || a.NameEn == "Trainging"))
                context.ServiceCategories.Add(new ServiceCategory() { Id = 2, NameAr = "التدريب", NameEn = "Trainging", IsDeleted = false, IsVisible = true });
            if (!context.ServiceCategories.Any(a => a.NameAr == "Supervision" || a.NameEn == "Supervision"))
                context.ServiceCategories.Add(new ServiceCategory() { Id = 3, NameAr = "الإشراف", NameEn = "Supervision", IsDeleted = false, IsVisible = true });

            if (!context.PTOffices.Any(a => a.Name == "Riyadh"))
                context.PTOffices.Add(new PTOffice() { Id = 1, Key = "Riyadh", Name = "Riyadh" });
            if (!context.PTOffices.Any(a => a.Name == "Central"))
                context.PTOffices.Add(new PTOffice() { Id = 2, Key = "Central", Name = "Central" });
            context.SaveChanges();

            context.PTOfficeCities.Add(new PTOfficeCity() { CityId = 1, FemalePTOfficeId = 1, PTOfficeId = 1 });

            if (!context.Services.Any(a => a.Name == "الموافقة المبدئية على ترخيص مستثمر"))
                context.Services.Add(new Service() { Id = 1, CategoryId = 1, Name = "الموافقة المبدئية على ترخيص مستثمر", AllowMultipleRequests = false, TermsAndConditions = "Lorem Lorem Lorem Lorem<br/>Lorem ", Order = 2, IsVisible = true, NominalClosureTimeInDays = 30, Description = "Lorem Lorem Lorem", Key = "InitialApproval" });
            if (!context.Services.Any(a => a.Name == "ترخيص مستثمر واستخراج رخصة منشأة تدريب"))
                context.Services.Add(new Service() { Id = 2, CategoryId = 1, Name = "ترخيص مستثمر واستخراج رخصة منشأة تدريب", AllowMultipleRequests = false, TermsAndConditions = "Lorem Lorem Lorem Lorem<br/>Lorem ", Order = 1, IsVisible = true, NominalClosureTimeInDays = 30, Description = "Lorem Lorem Lorem", Key = "LicenseIssuanceContainer" });
            if (!context.Services.Any(a => a.Name == "اعتما نشاط تدريبى"))
                context.Services.Add(new Service() { Id = 3, CategoryId = 2, Name = "اعتما نشاط تدريبى", AllowMultipleRequests = false, TermsAndConditions = "Lorem Lorem Lorem Lorem<br/>Lorem ", Order = 3, IsVisible = true, NominalClosureTimeInDays = 30, Description = "Lorem Lorem Lorem", Key = "TrainingProgramsApproval" });
            if (!context.Services.Any(a => a.Name == "اعتماد المقر والتجهيزات والهيئة الادارية واصدار الترخيص"))
                context.Services.Add(new Service() { Id = 4, CategoryId = 2, Name = "اعتماد المقر والتجهيزات والهيئة الادارية واصدار الترخيص", AllowMultipleRequests = false, TermsAndConditions = "Lorem Lorem Lorem Lorem<br/>Lorem ", Order = 4, IsVisible = true, NominalClosureTimeInDays = 30, Description = "Lorem Lorem Lorem", Key = "InstitutionApproval" });


            context.SaveChanges();
            //context.ServiceRequiredAttachments.Add(new Shared.Model.Entities.Attachments.ServiceRequiredAttachment() { ServiceId = 1, AttachmentTypeId = 1, FormSection = "Investor", IsMandatory = true });
            //context.ServiceRequiredAttachments.Add(new Shared.Model.Entities.Attachments.ServiceRequiredAttachment() { ServiceId = 1, AttachmentTypeId = 2, FormSection = "Initiator", IsMandatory = true });
            //context.ServiceRequiredAttachments.Add(new Shared.Model.Entities.Attachments.ServiceRequiredAttachment() { ServiceId = 1, AttachmentTypeId = 3, FormSection = "LegalRep", IsMandatory = true });

            if (context.NationalityIdentificationTypes.Count() < 7)
            {
                context.NationalityIdentificationTypes.Add(new NationalityIdentificationType() { IdentifcationDocumentTypeId = 1, NationalityId = 1 });
                context.NationalityIdentificationTypes.Add(new NationalityIdentificationType() { IdentifcationDocumentTypeId = 2, NationalityId = 2 });
                context.NationalityIdentificationTypes.Add(new NationalityIdentificationType() { IdentifcationDocumentTypeId = 3, NationalityId = 2 });
                context.NationalityIdentificationTypes.Add(new NationalityIdentificationType() { IdentifcationDocumentTypeId = 2, NationalityId = 3 });
                context.NationalityIdentificationTypes.Add(new NationalityIdentificationType() { IdentifcationDocumentTypeId = 3, NationalityId = 3 });
                context.NationalityIdentificationTypes.Add(new NationalityIdentificationType() { IdentifcationDocumentTypeId = 2, NationalityId = 4 });
                context.NationalityIdentificationTypes.Add(new NationalityIdentificationType() { IdentifcationDocumentTypeId = 3, NationalityId = 4 });
            }

            // context.Requests.Add(new Request { Creator = "mo.salem1@tvtc.gov.sa", PrincipalProvider = Shared.Model.Enums.AuthenticationMode.Forms, WfStatus = Shared.Model.Enums.WfStatus.Draft, ServiceId = 1, CreationDate = DateTime.Now });
            if (!context.AccountTypes.Any(a => a.NameAr == "فرد"))
                context.AccountTypes.Add(new AccountType { Id = (int)AccountTypeEnum.Individual, NameAr = "فرد" });
            if (!context.AccountTypes.Any(a => a.NameAr == "شركة"))
                context.AccountTypes.Add(new AccountType { Id = (int)AccountTypeEnum.Corporate, NameAr = "شركة" });
            //if (!context.AccountTypes.Any(a => a.NameAr == "هيئة / جمعية خيرية"))
            //    context.AccountTypes.Add(new AccountType { Id = (int)AccountTypeEnum.ProfessionalCommission, NameAr = "هيئة / جمعية خيرية" });
            if (!context.AccountTypes.Any(a => a.NameAr == "جمعية /مرسسة خيرية"))
                context.AccountTypes.Add(new AccountType { Id = (int)AccountTypeEnum.SocialDevelopment, NameAr = "جمعية /مرسسة خيرية" });

            if (!context.InvestmentTypes.Any(a => a.NameAr == "مجاني"))
                context.InvestmentTypes.Add(new InvestmentType { Id = (int)InvestmentTypeEnum.Free, NameAr = "مجاني", IsVisible = true });
            if (!context.InvestmentTypes.Any(a => a.NameAr == "تجاري"))
                context.InvestmentTypes.Add(new InvestmentType { Id = (int)InvestmentTypeEnum.Commercial, NameAr = "تجاري", IsVisible = true });

            if (!context.TrainingProgramPlans.Any(a => a.NameAr == "نصفي"))
                context.TrainingProgramPlans.Add(new TrainingProgramPlan { Id = (int)TrainingProgramPlanEnum.HalfAnnual, NameAr = "نصفي", IsVisible = true });
            if (!context.TrainingProgramPlans.Any(a => a.NameAr == "نصفي مجزأ"))
                context.TrainingProgramPlans.Add(new TrainingProgramPlan { Id = (int)TrainingProgramPlanEnum.Quarterly, NameAr = "نصفي مجزأ", IsVisible = true });


            //if (!context.TrainingProgramTypes.Any(a => a.NameAr == "جاهز"))
            //    context.TrainingProgramTypes.Add(new TrainingProgramType { Id = (int)TrainingProgramTypeEnum.Existing, NameAr = "جاهز", IsVisible = true });
            //if (!context.TrainingProgramTypes.Any(a => a.NameAr == "جديد"))
            //    context.TrainingProgramTypes.Add(new TrainingProgramType { Id = (int)TrainingProgramTypeEnum.New, NameAr = "جديد", IsVisible = true });

            //if (!context.TrainingProgramCategories.Any(a => a.NameAr == "مجالات تطويرية (لا تزيد عن شهر)"))
            //    context.TrainingProgramCategories.Add(new TrainingProgramCategory
            //    {
            //        Id = 1,
            //        TrainingProgramTypeId = (int)TrainingProgramTypeEnum.Existing,
            //        NameAr = "مجالات تطويرية (لا تزيد عن شهر)",
            //        PeriodInMonths = 1,
            //        IsVisible = true
            //    });

            //if (!context.TrainingProgramCategories.Any(a => a.NameAr == "دورات تأهيلية (أقل من سنة)"))
            //    context.TrainingProgramCategories.Add(new TrainingProgramCategory
            //    {
            //        Id = 2,
            //        TrainingProgramTypeId = (int)TrainingProgramTypeEnum.Existing,
            //        NameAr = "دورات تأهيلية (أقل من سنة)",
            //        PeriodInMonths = 12,
            //        IsVisible = true
            //    });
            //if (!context.TrainingProgramCategories.Any(a => a.NameAr == "برامج تأهيلية (أقل من سنتين)"))
            //    context.TrainingProgramCategories.Add(new TrainingProgramCategory
            //    {
            //        Id = 3,
            //        TrainingProgramTypeId = (int)TrainingProgramTypeEnum.Existing,
            //        NameAr = "برامج تأهيلية (أقل من سنتين)",
            //        PeriodInMonths = 24,
            //        IsVisible = true
            //    });
            //if (!context.TrainingProgramCategories.Any(a => a.NameAr == "دبلومات (من سنتين إلى ثلاث سنوات)"))
            //    context.TrainingProgramCategories.Add(new TrainingProgramCategory
            //    {
            //        Id = 4,
            //        TrainingProgramTypeId = (int)TrainingProgramTypeEnum.Existing,
            //        NameAr = "دبلومات (من سنتين إلى ثلاث سنوات)",
            //        PeriodInMonths = 36,
            //        IsVisible = true
            //    });
            //if (!context.TrainingProgramCategories.Any(a => a.NameAr == "دورات تأهيلية (أقل من سنة)"))
            //    context.TrainingProgramCategories.Add(new TrainingProgramCategory
            //    {
            //        Id = 5,
            //        TrainingProgramTypeId = (int)TrainingProgramTypeEnum.New,
            //        NameAr = "دورات تأهيلية (أقل من سنة)",
            //        PeriodInMonths = 12,
            //        IsVisible = true
            //    });
            //if (!context.TrainingProgramCategories.Any(a => a.NameAr == "برامج تأهيلية (أقل من سنتين)"))
            //    context.TrainingProgramCategories.Add(new TrainingProgramCategory
            //    {
            //        Id = 6,
            //        TrainingProgramTypeId = (int)TrainingProgramTypeEnum.New,
            //        NameAr = "برامج تأهيلية (أقل من سنتين)",
            //        PeriodInMonths = 24,
            //        IsVisible = true
            //    });
            //if (!context.TrainingProgramCategories.Any(a => a.NameAr == "دبلومات (من سنتين إلى ثلاث سنوات)"))
            //    context.TrainingProgramCategories.Add(new TrainingProgramCategory
            //    {
            //        Id = 7,
            //        TrainingProgramTypeId = (int)TrainingProgramTypeEnum.New,
            //        NameAr = "دبلومات (من سنتين إلى ثلاث سنوات)",
            //        PeriodInMonths = 36,
            //        IsVisible = true
            //    });

            //if (!context.CompanyTypes.Any(a => a.NameAr == "سعودية"))
            //    context.CompanyTypes.Add(new CompanyType
            //    {
            //        Id = (int)CompanyTypeEnum.Saudi,
            //        NameAr = "سعودية",
            //        IsVisible = true
            //    });
            //if (!context.CompanyTypes.Any(a => a.NameAr == "مختلطة"))
            //    context.CompanyTypes.Add(new CompanyType
            //    {
            //        Id = (int)CompanyTypeEnum.Mixed,
            //        NameAr = "مختلطة",
            //        IsVisible = true
            //    });
            //if (!context.CompanyTypes.Any(a => a.NameAr == "أجنبية"))
            //    context.CompanyTypes.Add(new CompanyType
            //    {
            //        Id = (int)CompanyTypeEnum.Forign,
            //        NameAr = "أجنبية",
            //        IsVisible = true
            //    });

            if (!context.InstitutionTypes.Any(a => a.NameAr == "معهد عالي"))
            {
                context.InstitutionTypes.Add(new InstitutionType
                {
                    Id = (int)InstitutionTypeEnum.HighInstitute,
                    NameAr = "معهد عالي",
                    IsVisible = true,
                    Prefix = "معهد",
                    Suffix = "العالي",
                    DefaultAreaInSquareMetre = 400,
                    RequirdBankDepositAmount = 150000
                });
            }
            else
            {
                var type = context.InstitutionTypes.Find((int)InstitutionTypeEnum.HighInstitute);
                type.DefaultAreaInSquareMetre = 400;
            }

            if (!context.InstitutionTypes.Any(a => a.NameAr == "معهد"))
            {
                context.InstitutionTypes.Add(new InstitutionType
                {
                    Id = (int)InstitutionTypeEnum.Institute,
                    NameAr = "معهد",
                    IsVisible = true,
                    Prefix = "معهد",
                    Suffix = "",
                    DefaultAreaInSquareMetre = 250,
                    RequirdBankDepositAmount = 75000
                });
            }
            else
            {
                var type = context.InstitutionTypes.Find((int)InstitutionTypeEnum.Institute);
                type.DefaultAreaInSquareMetre = 250;
            }

            if (!context.InstitutionTypes.Any(a => a.NameAr == "مركز"))
            {
                context.InstitutionTypes.Add(new InstitutionType
                {
                    Id = (int)InstitutionTypeEnum.Center,
                    NameAr = "مركز",
                    IsVisible = true,
                    Prefix = "مركز",
                    Suffix = "",
                    DefaultAreaInSquareMetre = 110,
                    RequirdBankDepositAmount = 50000
                });
            }
            else
            {
                var type = context.InstitutionTypes.Find((int)InstitutionTypeEnum.Center);
                type.DefaultAreaInSquareMetre = 110;
            }



            if (!context.BuildingTypes.Any(a => a.NameAr == "فيلا"))
                context.BuildingTypes.Add(new BuildingType
                {
                    Id = (int)BuildingTypeEnum.Villa,
                    NameAr = "فيلا",
                    IsVisible = true
                });
            if (!context.BuildingTypes.Any(a => a.NameAr == "عمارة"))
                context.BuildingTypes.Add(new BuildingType
                {
                    Id = (int)BuildingTypeEnum.Building,
                    NameAr = "عمارة",
                    IsVisible = true
                });

            if (!context.FloorNumbers.Any(a => a.NameAr == "تحت أرضي"))
                context.FloorNumbers.Add(new FloorNumber
                {
                    Id = 1,
                    NameAr = "تحت أرضي",
                    IsVisible = true
                });
            if (!context.FloorNumbers.Any(a => a.NameAr == "أرضي"))
                context.FloorNumbers.Add(new FloorNumber
                {
                    Id = 2,
                    NameAr = "أرضي",
                    IsVisible = true
                });
            for (int i = 1; i <= 100; i++)
            {
                if (!context.FloorNumbers.Any(a => a.NameAr == i.ToString()))
                    context.FloorNumbers.Add(new FloorNumber
                    {
                        Id = i + 2,
                        NameAr = i.ToString(),
                        IsVisible = true
                    });
            }

            if (!context.EquipmentClassifications.Any(a => a.NameAr == "قاعة متدربين"))
                context.EquipmentClassifications.Add(new EquipmentClassification
                {
                    Id = 1,
                    NameAr = "قاعة متدربين",
                    IsVisible = true,
                    Types = new List<EquipmentDetailsType>
                    {
                        new EquipmentDetailsType
                        {
                            Id =1,
                            NameAr = "قاعة تدريب نظري",
                            IsVisible=true
                        },
                        new EquipmentDetailsType
                        {
                            Id =2,
                            NameAr = "معمل حاسب",
                            IsVisible=true
                        }
                    }
                });

            if (!context.EquipmentClassifications.Any(a => a.NameAr == "مكتب إدارة"))
                context.EquipmentClassifications.Add(new EquipmentClassification
                {
                    Id = 2,
                    NameAr = "مكتب إدارة",
                    IsVisible = true,
                    Types = new List<EquipmentDetailsType>
                    {
                        new EquipmentDetailsType
                        {
                            Id =3,
                            NameAr = "مكتب الادارة",
                            IsVisible=true
                        },
                        new EquipmentDetailsType
                        {
                            Id =4,
                            NameAr = "مكتب المدير",
                            IsVisible=true
                        },
                        new EquipmentDetailsType
                        {
                            Id =5,
                            NameAr = "مكتب مدربين",
                            IsVisible=true
                        },
                        new EquipmentDetailsType
                        {
                            Id =6,
                            NameAr = "مكتب متدربين",
                            IsVisible=true
                        }
                    }
                });
            if (!context.EquipmentClassifications.Any(a => a.NameAr == "خدمات"))
                context.EquipmentClassifications.Add(new EquipmentClassification
                {
                    Id = 3,
                    NameAr = "خدمات",
                    IsVisible = true,
                    Types = new List<EquipmentDetailsType>
                    {
                        new EquipmentDetailsType
                        {
                            Id =7,
                            NameAr = "مكنب استقبال واستراحة المتدربين",
                            IsVisible=true
                        },
                        new EquipmentDetailsType
                        {
                            Id =8,
                            NameAr = "مصلي",
                            IsVisible=true
                        },
                        new EquipmentDetailsType
                        {
                            Id =9,
                            NameAr = "صالة/مكتب استقبال",
                            IsVisible=true
                        },
                         new EquipmentDetailsType
                        {
                            Id =10,
                            NameAr = "استراحة مدربين",
                            IsVisible=true
                        },
                          new EquipmentDetailsType
                        {
                            Id =11,
                            NameAr = "غرفة حارس",
                            IsVisible=true
                        },
                          new EquipmentDetailsType
                        {
                            Id =12,
                            NameAr = "مكتبة",
                            IsVisible=true
                        }
                }
                });

            if (!context.AnnouncementTypes.Any(a => a.NameAr == "تعاميم"))
                context.AnnouncementTypes.Add(new AnnouncementType
                {
                    Id = (int)AnnouncementTypeEnum.Announcement,
                    NameAr = "تعاميم"
                });
            if (!context.AnnouncementTypes.Any(a => a.NameAr == "أخبار"))
                context.AnnouncementTypes.Add(new AnnouncementType
                {
                    Id = (int)AnnouncementTypeEnum.News,
                    NameAr = "أخبار"
                });

            if (!context.AnnouncementVisibilities.Any(a => a.NameAr == "عام"))
                context.AnnouncementVisibilities.Add(new AnnouncementVisibility
                {
                    Id = (int)AnnouncementVisibilityEnum.Public,
                    NameAr = "عام"
                });
            if (!context.AnnouncementVisibilities.Any(a => a.NameAr == "داخلي"))
                context.AnnouncementVisibilities.Add(new AnnouncementVisibility
                {
                    Id = (int)AnnouncementVisibilityEnum.Internal,
                    NameAr = "داخلي"
                });
            if (!context.AnnouncementVisibilities.Any(a => a.NameAr == "مشترك"))
                context.AnnouncementVisibilities.Add(new AnnouncementVisibility
                {
                    Id = (int)AnnouncementVisibilityEnum.Shared,
                    NameAr = "مشترك"
                });

            if (!context.Announcements.Any())
            {
                for (int i = 1; i < 100; i++)
                {
                    var type = i < 50 ? 1 : 2;
                    var visiblity = 1;
                    if (i > 30 && i < 60)
                        visiblity = 2;
                    else if (i > 60)
                        visiblity = 3;

                    if (type == 0)
                        type = 1;
                    if (visiblity == 0)
                        visiblity = 1;

                    context.Announcements.Add(new Announcement
                    {
                        Title = "نموذج طلب التسجيل في البرامج التدريبية المنفذة لدى",
                        AnnouncementTypeId = type,
                        AnnouncementVisibilityId = visiblity,
                        CreationDate = DateTime.Now,
                        Date = DateTime.Now,
                        FullDetails = "رصاً من الادارة على التدريب باحدث التجهيزات والا صدارات المتوفرة من برامج الحاسب الألي، تود الإدا رة أن تنوه لمنشأت التدريب",
                        LastUpdateDate = DateTime.Now,
                        //PictureUrl = "http://91.221.22.244:8181/static/media/example.345dc835.png",
                        DateInHijri = DateTime.Now.ToString("MM/dd/yyyy", new CultureInfo(1025))
                    });
                }
            }



            // Job Types

            if (!context.JobTypes.Any(a => a.NameAr == "ادارى"))
                context.JobTypes.Add(new JobType
                {
                    Id = (int)JobTypeEnum.Administrator,
                    NameAr = "ادارى",
                    IsVisible = true
                });

            if (!context.JobTypes.Any(a => a.NameAr == "مدير"))
                context.JobTypes.Add(new JobType
                {
                    Id = (int)JobTypeEnum.Manager,
                    NameAr = "مدير",
                    IsVisible = true
                });

            context.SaveChanges();





        }

        private static void AddEquipmentType(GDPTDbContext context, EquipmentTypeEnum equipmentType, string title, EquipmentFieldTypeEnum type,
           bool isShared, string defaultValue, InstitutionTypeEnum? institutionType, bool hasDetails, int order, bool shareInCapacity,
           string tip, string unitOfMeasure, bool isRequired, int? categoryId = null)
        {
            AddEquipmentType(context, equipmentType, title, type, isShared, defaultValue, institutionType, hasDetails, order, shareInCapacity, tip, unitOfMeasure, isRequired, null, null, categoryId);
        }

        private static void AddEquipmentType(GDPTDbContext context, EquipmentTypeEnum equipmentType, string title, EquipmentFieldTypeEnum type,
            bool isShared, string defaultValue, InstitutionTypeEnum? institutionType, bool hasDetails, int order, bool shareInCapacity,
            string tip, string unitOfMeasure, bool isRequired, int? classificationId, int? typeId, int? categoryId)
        {
            if (!context.EquipmentTypes.Any(a => a.Name == equipmentType.ToString()))
            {
                var newItem = new EquipmentType
                {
                    Id = (int)equipmentType,
                    Name = equipmentType.ToString(),
                    NameAr = title,
                    DefaultValue = defaultValue,
                    FieldTypeId = (int)type,
                    HasDetails = hasDetails,
                    IsShared = isShared,
                    Order = order,
                    ShareInCapacity = shareInCapacity,
                    Tip = tip,
                    UnitOfMeasure = unitOfMeasure,
                    EquipmentTypeCategoryId = categoryId,
                    IsRequired = isRequired,
                    DetailsTypeId = typeId,
                    DetailsCassificationId = classificationId
                };

                if (institutionType != null)
                    newItem.InstitutionTypeId = (int)institutionType;

                context.EquipmentTypes.Add(newItem);
            }
        }
    }
}