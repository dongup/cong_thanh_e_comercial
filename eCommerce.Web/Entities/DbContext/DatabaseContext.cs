using eCommerce.Utils;
using eCommerce.Web.Entities.General;
using eCommerce.Web.Entities.Generals;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Entities.Installment;
using eCommerce.Web.Entities.Order;
using eCommerce.Web.Entities.Orders;
using eCommerce.Web.Entities.Post;
using eCommerce.Web.Entities.Product;
using eCommerce.Web.Entities.Product.ComboProduct;
using eCommerce.Web.Entities.Product.ProductGroup;
using eCommerce.Web.Entities.Promotion;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities
{
    public class DatabaseContext : IdentityDbContext<
        UserEntity,
        RoleEntity,
        int,
        UserClaimEntity,
        UserRoleEntity,
        UserLoginEntity,
        RoleClaimEntity,
        UserTokenEntity>
    {
        #region Products
        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<ProductBrandEntity> ProductBrands { get; set; }

        public DbSet<ProductImageEntity> ProductImages { get; set; }

        public DbSet<GiftProductEntity> GiftProducts { get; set; }

        public DbSet<ProductLogEntity> ProductLogs { get; set; }

        public DbSet<ProductPriceLogEntity> ProductPriceLogs { get; set; }

        public DbSet<ProductCategoryGroupEntity> ProductCategoryGroups { get; set; }

        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<BrandCategoryEntity> BrandCategories { get; set; }

        public DbSet<ComboEntity> Combos { get; set; }

        public DbSet<ComboProductEntity> ProductCombos { get; set; }
        public DbSet<ComboImagesEntity> ComboImages { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<ProductGroupEntity> ProductGroups { get; set; }


        #region Product property
        public DbSet<ProductPropertyEntity> ProductProperties { get; set; }

        public DbSet<ValueEntity> Values { get; set; }

        public DbSet<PropertyEntity> Properties { get; set; }

        public DbSet<TemplateEntity> Templates { get; set; }

        public DbSet<PropertyTemplateEntity> PropertyTemplates { get; set; }

        public DbSet<ProductPropertyValueEntity> ProductPropertyValues { get; set; }

        //public DbSet<PropertyValueEntity> PropertyValues { get; set; }
        #endregion


        public DbSet<CatergoryFilterEntity> CatergoryFilters { get; set; }

        //public DbSet<ProductCommentEntity> ProductComments { get; set; }
        #endregion
        #region Generals
        public DbSet<IntroduceEntity> Introduce { get; set; }

        public DbSet<ForderEntity> Forders { get; set; }

        public DbSet<InformationEntity> Information { get; set; }

        public DbSet<PopupEntity> Popups { get; set; }

        public DbSet<ContactEntity> Contracts { get; set; }

        public DbSet<OurBrandEntity> OurBrandEntities { get; set; }

        public DbSet<FileEntity> Files { get; set; }

        public DbSet<FriendlyUrlEntity> FriendlyUrls { get; set; }
        #endregion
        #region Promotions 
        public DbSet<PromotionProductEntity> PromotionProducts { get; set; }

        public DbSet<PromotionEntity> Promotions { get; set; }
        public DbSet<BannerAdsEntity> BannerAds { get; set; }
        #endregion
        #region Orders 
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<OrderHistoriesEntity> OrderHistories { get; set; }

        public DbSet<OrderDetailEntity> OrderDetails { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        //public DbSet<ProductRatingEntity> ProductRatings { get; set; }

        public DbSet<OrderNotificationEntity> OrderNotifications { get; set; }

        public DbSet<CartEntity> Carts { get; set; }

        public DbSet<BankEntity> Banks { get; set; }

        #endregion
        #region News
        public DbSet<PostEntity> Posts { get; set; }

        public DbSet<PostCategoryEntity> PostCategories { get; set; }
        #endregion
        #region Installment 
        public DbSet<InstallmentBankEntity> InstallmentBanks { get; set; }
        public DbSet<InstallmentOrderEntity> InstallmentOrders { get; set; }
        public DbSet<InstallmentPromotionEntity> InstallmentPromotions { get; set; }
        public DbSet<InstallmentPromotionProductEntity> InstallmentPromotionProducts { get; set; }

        #endregion
        private string ConnectionString { get; set; }

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        public DatabaseContext(string connStr)
        {
            ConnectionString = connStr;
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.EnableSensitiveDataLogging();
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            BuildModel(builder);
            SeedData(builder);
            QueryFilter(builder);
        }

        public void QueryFilter(ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                //1.Add the IsDeleted property
                //entityType.AddProperty("IsDeleted", typeof(bool)).SetDefaultValue(false);
                string name = entityType.DisplayName();

                //2.Create the query filter
                var parameter = Expression.Parameter(entityType.ClrType);

                // EF.Property<bool>(post, "IsDeleted")
                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
                var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsDeleted"));

                // EF.Property<bool>(post, "IsDeleted") == false
                BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));

                // post => EF.Property<bool>(post, "IsDeleted") == false
                var lambda = Expression.Lambda(compareExpression, parameter);

                builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            var entries = ChangeTracker.Entries();

            var countEntry = entries.Count();

            for (int i = 0; i < countEntry; i++)
            {
                var currentEntry = entries.FirstOrDefault();
                if (currentEntry.Entity.GetType() == typeof(UserEntity)) break;
                if (currentEntry == null) break;
                switch (currentEntry.State)
                {
                    case EntityState.Added:
                        currentEntry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        currentEntry.State = EntityState.Modified;
                        currentEntry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }

        public void BuildModel(ModelBuilder builder)
        {
            builder.Entity<PropertyEntity>()
              .HasOne(x => x.Category)
              .WithMany(x => x.Properties)
              .HasForeignKey(x => x.CategoryId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TemplateEntity>()
              .HasMany(x => x.PropertyTemplates)
              .WithOne(x => x.Template)
              .HasForeignKey(x => x.TemplateId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ProductImageEntity>()
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductImages)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ProductCategoryGroupEntity>()
                .HasMany(x => x.Categories)
                .WithOne(x => x.CategoryGroup)
                .HasForeignKey(x => x.CategoryGroupId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<CategoryEntity>()
                .HasMany(x => x.Templates)
                .WithOne(x => x.ProductCategory)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<FriendlyUrlEntity>()
            //    .HasIndex(x => x.FriendlyUrl)
            //    .IsUnique();

            builder.Entity<GiftProductEntity>()
                .HasOne(x => x.Product)
                .WithOne(x => x.GiftProduct)
                .HasForeignKey<GiftProductEntity>(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<OrderDetailEntity>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<UserRoleEntity>(x =>
            {
                x.HasOne(a => a.User)
                .WithMany(a => a.UserRoles)
                .HasForeignKey(a => a.UserId);

                x.HasOne(a => a.Role)
                .WithMany(a => a.UserRoles)
                .HasForeignKey(a => a.RoleId);
            });
        }

        public void SeedData(ModelBuilder builder)
        {

            //            public DbSet<InstallmentSupportMonthEntity> InstallmentSupportMonths { get; set; }
            //public DbSet<PrepayPercentEntity> PrepayPercents { get; set; }
            //builder.Entity<RoleEntity>()
            //    .HasData(
            //    new RoleEntity()
            //    {
            //        Id = 1,
            //        Name = "Admin",
            //        NormalizedName = "ADMIN"
            //    },
            //    new RoleEntity()
            //    {
            //        Id = 2,
            //        Name = "Sale",
            //        NormalizedName = "SALE"
            //    });

            //builder.Entity<InformationEntity>()
            //    .HasData(new InformationEntity()
            //    {
            //        Id = 1,
            //        Address = "12 Cách Mạng Tháng 8, Khu phố 4, Thành phố Biên Hòa, Đồng Nai",
            //        CompanyName = "Điện máy Công Thành",
            //        CreatedDate = DateTime.Now,
            //        CreatedUserId = 0,
            //        CSKH = "0251 3846 071",
            //        Email = "diemaycongthanh@gmail.com",
            //        Hotline = "0251 3846 071",
            //        Logo = "images/logo-trans.png",
            //        MailPassword = "",
            //        MailServer = "",
            //        ZaloAccessToken = "i6arD-rvS6EwQpOrwNvtOxrgDp7t82iofNSqO_bY2pMlBnSRWNK0EAGJ4WgGHJ4_eomg6BHx9Ixc0G09msiMEvGaC6cVOWzpdH0HFffH4cZ9Hr1-_pvgM-b4IcZeDt8wn7f2FPKeHI-yHM89ZZz43On8HG26F4bMga19K80nKLI7P1nChH0ZNRW3BtYhUMClWXT1UeHMQtRN9tHZosbtKVWeCdsfL0bwlHmgD-roBcIm7pDtbLC_RgKa8qhsNdjIn1ng1-fHKah726jSyn9oJlbLD5RpG35RCcGZTM3dP7LY",
            //        ZaloOAId = "",
            //        ZaloRecipientIds = "",
            //        FbAppId = "",
            //        FbAccessToken = "",
            //        YoutubeUrl = "https://www.youtube.com/channel/UCbtXSF9V3o9vEZ7-BfbTRZg",
            //        FacebookUrl = "https://www.facebook.com/DIENMAYCONGTHANH0914196139/",
            //    });

            //builder.Entity<IntroduceEntity>()
            //    .HasData(new IntroduceEntity()
            //    {
            //        Id = 1,
            //        BannerImages = "394",
            //        CreatedDate = DateTime.Now,
            //        Introduction = "<p>Tại Điện M&aacute;y C&ocirc;ng Th&agrave;nh, ch&uacute;ng t&ocirc;i lu&ocirc;n đề cao trải nghiệm kh&aacute;ch h&agrave;ng v&agrave; sự h&agrave;i h&ograve;a giữa c&aacute;c gi&aacute; trị khởi nguồn từ triết l&yacute; &acirc;m &ndash; dương. Chọn đ&ocirc;i b&agrave;n tay giữ lửa l&agrave;m h&igrave;nh ảnh đại diện để thể hiện sứ mệnh cả đời m&agrave; ch&uacute;ng t&ocirc;i theo đuổi &ndash; sự c&ocirc;ng minh v&agrave; ch&iacute;nh trực, sự c&acirc;n bằng giữa văn h&oacute;a đương đại v&agrave; truyền thống &Aacute; Đ&ocirc;ng, giữa lợi &iacute;ch kinh doanh v&agrave; gi&aacute; trị cộng đồng.</p>",
            //        ProductCategories = "1",
            //        PostId = 1,
            //    });

            //builder.Entity<FriendlyUrlEntity>().HasData(new FriendlyUrlEntity()
            //{
            //    Id = 1,
            //    Type = FriendlyUrlEntity.UrlType.Promotion,
            //    FriendlyUrl = "gia-tot-hom-nay"
            //});

            //builder.Entity<FriendlyUrlEntity>().HasData(new FriendlyUrlEntity()
            //{
            //    Id = 1,
            //    Type = FriendlyUrlEntity.UrlType.ProductCategory,
            //    FriendlyUrl = "san-pham"
            //});
        }
    }
}
