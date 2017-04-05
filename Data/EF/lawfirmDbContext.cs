namespace Data.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class lawfirmDbContext : DbContext
    {
        public lawfirmDbContext()
            : base("name=lawfirmDbContext")
        {
        }

        public virtual DbSet<TN_AcountType> TN_AcountType { get; set; }
        public virtual DbSet<TN_CapHoc> TN_CapHoc { get; set; }
        public virtual DbSet<TN_CauHoi> TN_CauHoi { get; set; }
        public virtual DbSet<TN_CauHoi_DapAn> TN_CauHoi_DapAn { get; set; }
        public virtual DbSet<TN_Country> TN_Country { get; set; }
        public virtual DbSet<TN_DapAn> TN_DapAn { get; set; }
        public virtual DbSet<TN_Districts> TN_Districts { get; set; }
        public virtual DbSet<TN_Job> TN_Job { get; set; }
        public virtual DbSet<TN_KhoiLopHoc> TN_KhoiLopHoc { get; set; }
        public virtual DbSet<TN_MonHoc> TN_MonHoc { get; set; }
        public virtual DbSet<TN_NhomMonHoc> TN_NhomMonHoc { get; set; }
        public virtual DbSet<TN_Provinces> TN_Provinces { get; set; }
        public virtual DbSet<TN_Question_DapAn> TN_Question_DapAn { get; set; }
        public virtual DbSet<TN_QuestionLevel> TN_QuestionLevel { get; set; }
        public virtual DbSet<TN_Questions> TN_Questions { get; set; }
        public virtual DbSet<TN_Result> TN_Result { get; set; }
        public virtual DbSet<TN_StatusTest> TN_StatusTest { get; set; }
        public virtual DbSet<TN_Subject> TN_Subject { get; set; }
        public virtual DbSet<TN_Test> TN_Test { get; set; }
        public virtual DbSet<TN_TestDetails> TN_TestDetails { get; set; }
        public virtual DbSet<TN_TestType> TN_TestType { get; set; }
        public virtual DbSet<TN_TinTuc> TN_TinTuc { get; set; }
        public virtual DbSet<TN_TinTucLoai> TN_TinTucLoai { get; set; }
        public virtual DbSet<TN_Type> TN_Type { get; set; }
        public virtual DbSet<TN_User> TN_User { get; set; }
        public virtual DbSet<TN_UserType> TN_UserType { get; set; }
        public virtual DbSet<TN_Wards> TN_Wards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TN_CapHoc>()
                .HasMany(e => e.TN_KhoiLopHoc)
                .WithOptional(e => e.TN_CapHoc)
                .HasForeignKey(e => e.CapHoc_Id);

            modelBuilder.Entity<TN_CauHoi>()
                .HasMany(e => e.TN_CauHoi_DapAn)
                .WithRequired(e => e.TN_CauHoi)
                .HasForeignKey(e => e.CauHoi_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TN_CauHoi>()
                .HasMany(e => e.TN_TestDetails)
                .WithOptional(e => e.TN_CauHoi)
                .HasForeignKey(e => e.CauHoiId);

            modelBuilder.Entity<TN_Country>()
                .HasMany(e => e.TN_Provinces)
                .WithOptional(e => e.TN_Country)
                .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<TN_Country>()
                .HasMany(e => e.TN_User)
                .WithOptional(e => e.TN_Country)
                .HasForeignKey(e => e.CountryId);

            modelBuilder.Entity<TN_DapAn>()
                .HasMany(e => e.TN_CauHoi_DapAn)
                .WithRequired(e => e.TN_DapAn)
                .HasForeignKey(e => e.DapAn_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TN_DapAn>()
                .HasMany(e => e.TN_Question_DapAn)
                .WithRequired(e => e.TN_DapAn)
                .HasForeignKey(e => e.DapAn_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TN_DapAn>()
                .HasMany(e => e.TN_TestDetails)
                .WithOptional(e => e.TN_DapAn)
                .HasForeignKey(e => e.DapAnId);

            modelBuilder.Entity<TN_Districts>()
                .HasMany(e => e.TN_User)
                .WithOptional(e => e.TN_Districts)
                .HasForeignKey(e => e.DistrictId);

            modelBuilder.Entity<TN_Districts>()
                .HasMany(e => e.TN_Wards)
                .WithOptional(e => e.TN_Districts)
                .HasForeignKey(e => e.DistricId);

            modelBuilder.Entity<TN_Job>()
                .HasMany(e => e.TN_User)
                .WithOptional(e => e.TN_Job)
                .HasForeignKey(e => e.JobId);

            modelBuilder.Entity<TN_KhoiLopHoc>()
                .HasMany(e => e.TN_MonHoc)
                .WithOptional(e => e.TN_KhoiLopHoc)
                .HasForeignKey(e => e.LopHoc_Id);

            modelBuilder.Entity<TN_MonHoc>()
                .HasMany(e => e.TN_CauHoi)
                .WithOptional(e => e.TN_MonHoc)
                .HasForeignKey(e => e.MonHoc_Id);

            modelBuilder.Entity<TN_Provinces>()
                .HasMany(e => e.TN_Districts)
                .WithOptional(e => e.TN_Provinces)
                .HasForeignKey(e => e.ProvinceId);

            modelBuilder.Entity<TN_Provinces>()
                .HasMany(e => e.TN_User)
                .WithOptional(e => e.TN_Provinces)
                .HasForeignKey(e => e.ProvinceId);

            modelBuilder.Entity<TN_QuestionLevel>()
                .HasMany(e => e.TN_CauHoi)
                .WithOptional(e => e.TN_QuestionLevel)
                .HasForeignKey(e => e.QuestionLevelId);

            modelBuilder.Entity<TN_QuestionLevel>()
                .HasMany(e => e.TN_Questions)
                .WithOptional(e => e.TN_QuestionLevel)
                .HasForeignKey(e => e.QuestionLevelId);

            modelBuilder.Entity<TN_QuestionLevel>()
                .HasMany(e => e.TN_Test)
                .WithOptional(e => e.TN_QuestionLevel)
                .HasForeignKey(e => e.QuestionLevelId);

            modelBuilder.Entity<TN_Questions>()
                .HasMany(e => e.TN_Question_DapAn)
                .WithRequired(e => e.TN_Questions)
                .HasForeignKey(e => e.Question_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TN_Result>()
                .HasMany(e => e.TN_Test)
                .WithOptional(e => e.TN_Result)
                .HasForeignKey(e => e.ResultId);

            modelBuilder.Entity<TN_Subject>()
                .HasMany(e => e.TN_Questions)
                .WithOptional(e => e.TN_Subject)
                .HasForeignKey(e => e.SubjectId);

            modelBuilder.Entity<TN_Test>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<TN_Test>()
                .HasMany(e => e.TN_TestDetails)
                .WithOptional(e => e.TN_Test)
                .HasForeignKey(e => e.TestId);

            modelBuilder.Entity<TN_TestType>()
                .HasMany(e => e.TN_CauHoi)
                .WithOptional(e => e.TN_TestType)
                .HasForeignKey(e => e.TestTypeId);

            modelBuilder.Entity<TN_TestType>()
                .HasMany(e => e.TN_Questions)
                .WithOptional(e => e.TN_TestType)
                .HasForeignKey(e => e.TestTypeId);

            modelBuilder.Entity<TN_TestType>()
                .HasMany(e => e.TN_Subject)
                .WithOptional(e => e.TN_TestType)
                .HasForeignKey(e => e.TestTypeId);

            modelBuilder.Entity<TN_TestType>()
                .HasMany(e => e.TN_Test)
                .WithOptional(e => e.TN_TestType)
                .HasForeignKey(e => e.TestTypeId);

            modelBuilder.Entity<TN_TinTuc>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<TN_TinTucLoai>()
                .HasMany(e => e.TN_TinTuc)
                .WithOptional(e => e.TN_TinTucLoai)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<TN_Type>()
                .HasMany(e => e.TN_TestType)
                .WithOptional(e => e.TN_Type)
                .HasForeignKey(e => e.TypeId);

            modelBuilder.Entity<TN_User>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<TN_User>()
                .HasMany(e => e.TN_Test)
                .WithOptional(e => e.TN_User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<TN_UserType>()
                .HasMany(e => e.TN_User)
                .WithOptional(e => e.TN_UserType)
                .HasForeignKey(e => e.UserTypeId);

            modelBuilder.Entity<TN_Wards>()
                .HasMany(e => e.TN_User)
                .WithOptional(e => e.TN_Wards)
                .HasForeignKey(e => e.WardId);
        }
    }
}
