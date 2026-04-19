using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Online_Store_Backend_WebAPI.DB.Data;

namespace Online_Store_Backend_WebAPI.DB;

public partial class AppContext : Microsoft.EntityFrameworkCore.DbContext{
    public AppContext(DbContextOptions<AppContext> options)
        : base(options) {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<BundleItem> BundleItems { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<GameMedium> GameMedia { get; set; }

    public virtual DbSet<GamePrice> GamePrices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<PublisherMembership> PublisherMemberships { get; set; }

    public virtual DbSet<Refund> Refunds { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserLibrary> UserLibraries { get; set; }

    public virtual DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=store;user=app;password=pass", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.45-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AuditLog>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("audit_logs");

            entity.HasIndex(e => new { e.ActorUserId, e.CreatedAt }, "idx_audit_actor_created");

            entity.HasIndex(e => new { e.EntityType, e.EntityId }, "idx_audit_entity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(128)
                .HasColumnName("action");
            entity.Property(e => e.ActorUserId).HasColumnName("actor_user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.EntityType)
                .HasMaxLength(64)
                .HasColumnName("entity_type");
            entity.Property(e => e.Metadata)
                .HasColumnType("json")
                .HasColumnName("metadata");

            entity.HasOne(d => d.ActorUser).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.ActorUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_audit_actor");
        });

        modelBuilder.Entity<BundleItem>(entity => {
            entity.HasKey(e => new { e.BundleProductId, e.ItemProductId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("bundle_items");

            entity.HasIndex(e => e.ItemProductId, "fk_bi_item");

            entity.Property(e => e.BundleProductId).HasColumnName("bundle_product_id");
            entity.Property(e => e.ItemProductId).HasColumnName("item_product_id");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnName("quantity");

            entity.HasOne(d => d.BundleProduct).WithMany(p => p.BundleItemBundleProducts)
                .HasForeignKey(d => d.BundleProductId)
                .HasConstraintName("fk_bi_bundle");

            entity.HasOne(d => d.ItemProduct).WithMany(p => p.BundleItemItemProducts)
                .HasForeignKey(d => d.ItemProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_bi_item");
        });

        modelBuilder.Entity<Cart>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("carts");

            entity.HasIndex(e => e.UserId, "idx_carts_user");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_carts_user");
        });

        modelBuilder.Entity<CartItem>(entity => {
            entity.HasKey(e => new { e.CartId, e.ProductId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("cart_items");

            entity.HasIndex(e => e.ProductId, "fk_ci_product");

            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("added_at");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnName("quantity");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("fk_ci_cart");

            entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ci_product");
        });

        modelBuilder.Entity<Game>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("games");

            entity.HasIndex(e => e.PublisherId, "idx_games_publisher");

            entity.HasIndex(e => e.Status, "idx_games_status");

            entity.HasIndex(e => e.Slug, "uq_games_slug").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.LongDescription)
                .HasColumnType("text")
                .HasColumnName("long_description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(512)
                .HasColumnName("short_description");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'draft'")
                .HasColumnType("enum('draft','coming_soon','released','delisted')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Publisher).WithMany(p => p.Games)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_games_publisher");

            entity.HasMany(d => d.Tags).WithMany(p => p.Games)
                .UsingEntity<Dictionary<string, object>>(
                    "GameTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_gt_tag"),
                    l => l.HasOne<Game>().WithMany()
                        .HasForeignKey("GameId")
                        .HasConstraintName("fk_gt_game"),
                    j => {
                        j.HasKey("GameId", "TagId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("game_tags");
                        j.HasIndex(new[] { "TagId" }, "idx_gt_tag");
                        j.IndexerProperty<ulong>("GameId").HasColumnName("game_id");
                        j.IndexerProperty<ulong>("TagId").HasColumnName("tag_id");
                    });
        });

        modelBuilder.Entity<GameMedium>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("game_media");

            entity.HasIndex(e => new { e.GameId, e.Type, e.SortOrder }, "idx_gm_game_type_sort");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.SortOrder).HasColumnName("sort_order");
            entity.Property(e => e.Type)
                .HasColumnType("enum('header','capsule','screenshot','trailer')")
                .HasColumnName("type");
            entity.Property(e => e.Url)
                .HasMaxLength(2048)
                .HasColumnName("url");

            entity.HasOne(d => d.Game).WithMany(p => p.GameMedia)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("fk_gm_game");
        });

        modelBuilder.Entity<GamePrice>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("game_prices");

            entity.HasIndex(e => e.CurrencyCode, "idx_gp_currency");

            entity.HasIndex(e => new { e.GameId, e.RegionCode }, "uq_gp_game_region").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(8)
                .HasColumnName("currency_code");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.PriceMinor).HasColumnName("price_minor");
            entity.Property(e => e.RegionCode)
                .HasMaxLength(8)
                .HasColumnName("region_code");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Game).WithMany(p => p.GamePrices)
                .HasForeignKey(d => d.GameId)
                .HasConstraintName("fk_gp_game");
        });

        modelBuilder.Entity<Order>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.Status, "idx_orders_status");

            entity.HasIndex(e => new { e.UserId, e.CreatedAt }, "idx_orders_user_created");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(8)
                .HasColumnName("currency_code");
            entity.Property(e => e.PaidAt)
                .HasColumnType("timestamp")
                .HasColumnName("paid_at");
            entity.Property(e => e.RegionCode)
                .HasMaxLength(8)
                .HasColumnName("region_code");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('pending','paid','failed','refunded','chargeback','canceled')")
                .HasColumnName("status");
            entity.Property(e => e.SubtotalMinor).HasColumnName("subtotal_minor");
            entity.Property(e => e.TaxMinor).HasColumnName("tax_minor");
            entity.Property(e => e.TotalMinor).HasColumnName("total_minor");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_orders_user");
        });

        modelBuilder.Entity<OrderItem>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("order_items");

            entity.HasIndex(e => e.OrderId, "idx_oi_order");

            entity.HasIndex(e => e.ProductId, "idx_oi_product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.DiscountMinor).HasColumnName("discount_minor");
            entity.Property(e => e.FinalPriceMinor).HasColumnName("final_price_minor");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnName("quantity");
            entity.Property(e => e.UnitPriceMinor).HasColumnName("unit_price_minor");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_oi_order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_oi_product");
        });

        modelBuilder.Entity<Payment>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payments");

            entity.HasIndex(e => e.OrderId, "idx_payments_order");

            entity.HasIndex(e => e.Status, "idx_payments_status");

            entity.HasIndex(e => e.ProviderPaymentId, "uq_payments_provider_pid").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountMinor).HasColumnName("amount_minor");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(8)
                .HasColumnName("currency_code");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Provider)
                .HasMaxLength(64)
                .HasColumnName("provider");
            entity.Property(e => e.ProviderPaymentId).HasColumnName("provider_payment_id");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'pending'")
                .HasColumnType("enum('pending','authorized','captured','failed','refunded','chargeback')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("fk_payments_order");
        });

        modelBuilder.Entity<Product>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.GameId, "idx_products_game");

            entity.HasIndex(e => e.Type, "idx_products_type");

            entity.HasIndex(e => e.Slug, "uq_products_slug").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.Type)
                .HasColumnType("enum('game','dlc','soundtrack','bundle')")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Game).WithMany(p => p.Products)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_products_game");
        });

        modelBuilder.Entity<Publisher>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("publishers");

            entity.HasIndex(e => e.Slug, "uq_publishers_slug").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.LogoUrl)
                .HasMaxLength(2048)
                .HasColumnName("logo_url");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Slug).HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Website)
                .HasMaxLength(2048)
                .HasColumnName("website");
        });

        modelBuilder.Entity<PublisherMembership>(entity => {
            entity.HasKey(e => new { e.PublisherId, e.UserId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("publisher_memberships");

            entity.HasIndex(e => e.UserId, "idx_pm_user");

            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Role)
                .HasDefaultValueSql("'editor'")
                .HasColumnType("enum('owner','admin','editor','finance')")
                .HasColumnName("role");

            entity.HasOne(d => d.Publisher).WithMany(p => p.PublisherMemberships)
                .HasForeignKey(d => d.PublisherId)
                .HasConstraintName("fk_pm_publisher");

            entity.HasOne(d => d.User).WithMany(p => p.PublisherMemberships)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_pm_user");
        });

        modelBuilder.Entity<Refund>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refunds");

            entity.HasIndex(e => e.PaymentId, "idx_refunds_payment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmountMinor).HasColumnName("amount_minor");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");

            entity.HasOne(d => d.Payment).WithMany(p => p.Refunds)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("fk_refunds_payment");
        });

        modelBuilder.Entity<Review>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reviews");

            entity.HasIndex(e => e.ProductId, "idx_reviews_product");

            entity.HasIndex(e => new { e.UserId, e.ProductId }, "uq_reviews_user_product").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Body)
                .HasColumnType("text")
                .HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.PlaytimeMinutesAtReview).HasColumnName("playtime_minutes_at_review");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Rating)
                .HasColumnType("enum('recommended','not_recommended')")
                .HasColumnName("rating");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_reviews_product");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_reviews_user");
        });

        modelBuilder.Entity<Tag>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tags");

            entity.HasIndex(e => e.Name, "uq_tags_name").IsUnique();

            entity.HasIndex(e => e.Slug, "uq_tags_slug").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Slug).HasColumnName("slug");
        });

        modelBuilder.Entity<User>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "uq_users_email").IsUnique();

            entity.HasIndex(e => e.Username, "uq_users_username").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'active'")
                .HasColumnType("enum('active','banned','deleted')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(64)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserLibrary>(entity => {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_library");

            entity.HasIndex(e => e.OrderId, "idx_ul_order");

            entity.HasIndex(e => e.ProductId, "idx_ul_product");

            entity.HasIndex(e => e.UserId, "idx_ul_user");

            entity.HasIndex(e => new { e.UserId, e.ProductId }, "uq_ul_user_product").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GrantedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("granted_at");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Source)
                .HasDefaultValueSql("'purchase'")
                .HasColumnType("enum('purchase','gift','key','promo')")
                .HasColumnName("source");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Order).WithMany(p => p.UserLibraries)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_ul_order");

            entity.HasOne(d => d.Product).WithMany(p => p.UserLibraries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ul_product");

            entity.HasOne(d => d.User).WithMany(p => p.UserLibraries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_ul_user");
        });

        modelBuilder.Entity<Wishlist>(entity => {
            entity.HasKey(e => new { e.UserId, e.ProductId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("wishlists");

            entity.HasIndex(e => e.ProductId, "idx_wl_product");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");

            entity.HasOne(d => d.Product).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("fk_wl_product");

            entity.HasOne(d => d.User).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("fk_wl_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
