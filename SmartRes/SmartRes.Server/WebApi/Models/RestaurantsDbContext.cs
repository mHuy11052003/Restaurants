using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmartRes.Server.WebApi.Models;

public partial class RestaurantsDbContext : DbContext
{
    public RestaurantsDbContext()
    {
    }

    public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }

    public virtual DbSet<LoyaltyProgram> LoyaltyPrograms { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<MenuItemsIngredient> MenuItemsIngredients { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffAttendance> StaffAttendances { get; set; }

    public virtual DbSet<StaffLeave> StaffLeaves { get; set; }

    public virtual DbSet<StaffSalary> StaffSalaries { get; set; }

    public virtual DbSet<StaffSchedule> StaffSchedules { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SuppliersContact> SuppliersContacts { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost;Database=Restaurants;User Id=sa;Password=11052003huy;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB857F1C88F3");

            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("customer_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasDefaultValue("255")
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasDefaultValue("255")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasDefaultValue("100")
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasDefaultValue("Unknown")
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasDefaultValue("100")
                .HasColumnName("last_name");
            entity.Property(e => e.LoyaltyPoints)
                .HasDefaultValue(0)
                .HasColumnName("loyalty_points");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasDefaultValue("15")
                .HasColumnName("phone_number");
            entity.Property(e => e.Preferences)
                .HasMaxLength(500)
                .HasColumnName("preferences");
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(255)
                .HasDefaultValue("default.jpg")
                .HasColumnName("profile_picture");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountId).HasName("PK__Discount__BDBE9EF9483DC246");

            entity.Property(e => e.DiscountId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("discount_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CustomerIdFk).HasColumnName("customer_id_fk");
            entity.Property(e => e.DiscountCode)
                .HasMaxLength(50)
                .HasDefaultValue("DISCOUNT50")
                .HasColumnName("discount_code");
            entity.Property(e => e.DiscountDescription)
                .HasMaxLength(500)
                .HasColumnName("discount_description");
            entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
            entity.Property(e => e.RestaurantIdFk).HasColumnName("restaurant_id_fk");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.ValidFrom)
                .HasColumnType("datetime")
                .HasColumnName("valid_from");
            entity.Property(e => e.ValidTo)
                .HasColumnType("datetime")
                .HasColumnName("valid_to");

            entity.HasOne(d => d.RestaurantIdFkNavigation).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.RestaurantIdFk)
                .HasConstraintName("Discounts_fk1");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Events__2370F727C4CB3590");

            entity.Property(e => e.EventId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("event_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EventDate)
                .HasColumnType("datetime")
                .HasColumnName("event_date");
            entity.Property(e => e.EventName)
                .HasMaxLength(255)
                .HasDefaultValue("Event Name")
                .HasColumnName("event_name");
            entity.Property(e => e.EventType).HasColumnName("event_type");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasDefaultValue("Image URL")
                .HasColumnName("image_url");
            entity.Property(e => e.MaxAttendees).HasColumnName("max_attendees");
            entity.Property(e => e.RestaurantIdFk).HasColumnName("restaurant_id_fk");
            entity.Property(e => e.SpecialRequests).HasColumnName("special_requests");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TicketPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ticket_price");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.RestaurantIdFkNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.RestaurantIdFk)
                .HasConstraintName("Events_fk12");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__7A6B2B8CA3B5A787");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("feedback_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CustomerIdFk).HasColumnName("customer_id_fk");
            entity.Property(e => e.FeedbackText)
                .HasMaxLength(1000)
                .HasColumnName("feedback_text");
            entity.Property(e => e.FeedbackType).HasColumnName("feedback_type");
            entity.Property(e => e.HelpfulVotes).HasColumnName("helpful_votes");
            entity.Property(e => e.IsAnonymous).HasColumnName("is_anonymous");
            entity.Property(e => e.IsResolved).HasColumnName("is_resolved");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Response).HasColumnName("response");
            entity.Property(e => e.ResponseDate)
                .HasColumnType("datetime")
                .HasColumnName("response_date");
            entity.Property(e => e.RestaurantIdFk).HasColumnName("restaurant_id_fk");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CustomerIdFkNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerIdFk)
                .HasConstraintName("Feedback_fk13");

            entity.HasOne(d => d.RestaurantIdFkNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.RestaurantIdFk)
                .HasConstraintName("Feedback_fk15");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__Inventor__B59ACC49BFFB7060");

            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("inventory_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IngredientName)
                .HasMaxLength(255)
                .HasColumnName("ingredient_name");
            entity.Property(e => e.QuantityInStock)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("quantity_in_stock");
            entity.Property(e => e.ReceivedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("received_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("C?n")
                .HasColumnName("status");
            entity.Property(e => e.SupplierIdFk).HasColumnName("supplier_id_fk");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasColumnName("unit");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.SupplierIdFkNavigation).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.SupplierIdFk)
                .HasConstraintName("FK__Inventory__suppl__0C50D423");
        });

        modelBuilder.Entity<InventoryTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Inventor__85C600AFD5AFB62C");

            entity.Property(e => e.TransactionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("transaction_id");
            entity.Property(e => e.InventoryIdFk).HasColumnName("inventory_id_fk");
            entity.Property(e => e.QuantityChanged)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("quantity_changed");
            entity.Property(e => e.TransactionBy).HasColumnName("transaction_by");
            entity.Property(e => e.TransactionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionReason)
                .HasMaxLength(255)
                .HasColumnName("transaction_reason");

            entity.HasOne(d => d.InventoryIdFkNavigation).WithMany(p => p.InventoryTransactions)
                .HasForeignKey(d => d.InventoryIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ingredient_InventoryTransaction");
        });

        modelBuilder.Entity<LoyaltyProgram>(entity =>
        {
            entity.HasKey(e => e.LoyaltyProgramId).HasName("PK__LoyaltyP__0022970AD77E5802");

            entity.Property(e => e.LoyaltyProgramId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("loyalty_program_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");
            entity.Property(e => e.EnrollmentDate)
                .HasColumnType("datetime")
                .HasColumnName("enrollment_date");
            entity.Property(e => e.MaxPoints).HasColumnName("max_points");
            entity.Property(e => e.MinPoints).HasColumnName("min_points");
            entity.Property(e => e.PointsRequired).HasColumnName("points_required");
            entity.Property(e => e.ProgramName)
                .HasMaxLength(255)
                .HasDefaultValue("Discount Program")
                .HasColumnName("program_name");
            entity.Property(e => e.RestaurantIdFk).HasColumnName("restaurant_id_fk");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TermsConditions)
                .HasMaxLength(1000)
                .HasColumnName("terms_conditions");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.ValidityPeriod).HasColumnName("validity_period");

            entity.HasOne(d => d.RestaurantIdFkNavigation).WithMany(p => p.LoyaltyPrograms)
                .HasForeignKey(d => d.RestaurantIdFk)
                .HasConstraintName("LoyaltyPrograms_fk14");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menus__4CA0FADC2D37FB4A");

            entity.Property(e => e.MenuId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("menu_id");
            entity.Property(e => e.AvailableFrom)
                .HasColumnType("datetime")
                .HasColumnName("available_from");
            entity.Property(e => e.AvailableTo)
                .HasColumnType("datetime")
                .HasColumnName("available_to");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsSpecial).HasColumnName("is_special");
            entity.Property(e => e.MenuName)
                .HasMaxLength(255)
                .HasColumnName("menu_name");
            entity.Property(e => e.MenuType)
                .HasMaxLength(50)
                .HasDefaultValue("10")
                .HasColumnName("menu_type");
            entity.Property(e => e.PriceRange)
                .HasMaxLength(50)
                .HasDefaultValue("50")
                .HasColumnName("price_range");
            entity.Property(e => e.RestaurantIdFk).HasColumnName("restaurant_id_fk");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.RestaurantIdFkNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.RestaurantIdFk)
                .HasConstraintName("Menus_fk13");
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__MenuItem__52020FDD81574386");

            entity.Property(e => e.ItemId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("item_id");
            entity.Property(e => e.Allergens)
                .HasMaxLength(255)
                .HasColumnName("allergens");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsAvailable).HasColumnName("is_available");
            entity.Property(e => e.ItemName)
                .HasMaxLength(255)
                .HasColumnName("item_name");
            entity.Property(e => e.ItemType)
                .HasMaxLength(50)
                .HasColumnName("item_type");
            entity.Property(e => e.MenuIdFk).HasColumnName("menu_id_fk");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.SpiceLevel)
                .HasMaxLength(50)
                .HasColumnName("spice_level");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.MenuIdFkNavigation).WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.MenuIdFk)
                .HasConstraintName("MenuItems_fk1");
        });

        modelBuilder.Entity<MenuItemsIngredient>(entity =>
        {
            entity.HasKey(e => e.MenuitemsIngredientId).HasName("PK__MenuItem__847DD8F223CE177B");

            entity.ToTable("MenuItemsIngredient");

            entity.Property(e => e.MenuitemsIngredientId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("menuitems_ingredient_id");
            entity.Property(e => e.IngredientIdFk).HasColumnName("ingredient_id_fk");
            entity.Property(e => e.MenuitemsIdFk).HasColumnName("menuitems_id_fk");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .HasColumnName("unit");

            entity.HasOne(d => d.IngredientIdFkNavigation).WithMany(p => p.MenuItemsIngredients)
                .HasForeignKey(d => d.IngredientIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MenuItems__ingre__11158940");

            entity.HasOne(d => d.MenuitemsIdFkNavigation).WithMany(p => p.MenuItemsIngredients)
                .HasForeignKey(d => d.MenuitemsIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MenuItems__menui__10216507");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__E059842F5B2B1BCA");

            entity.Property(e => e.NotificationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("notification_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CustomerFeedback)
                .HasMaxLength(1000)
                .HasColumnName("customer_feedback");
            entity.Property(e => e.CustomerIdFk).HasColumnName("customer_id_fk");
            entity.Property(e => e.ExpirationDate)
                .HasColumnType("datetime")
                .HasColumnName("expiration_date");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.Message)
                .HasMaxLength(1000)
                .HasColumnName("message");
            entity.Property(e => e.NotificationType).HasColumnName("notification_type");
            entity.Property(e => e.Priority)
                .HasMaxLength(10)
                .HasDefaultValue("Medium")
                .HasColumnName("priority");
            entity.Property(e => e.RelatedId).HasColumnName("related_id");
            entity.Property(e => e.ResponseDate)
                .HasColumnType("datetime")
                .HasColumnName("response_date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CustomerIdFkNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.CustomerIdFk)
                .HasConstraintName("Notifications_fk13");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__4659622974A8C2FA");

            entity.Property(e => e.OrderId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("order_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomerFeedback).HasColumnName("customer_feedback");
            entity.Property(e => e.CustomerIdFk).HasColumnName("customer_id_fk");
            entity.Property(e => e.DeliveryAddress)
                .HasMaxLength(255)
                .HasDefaultValue("255")
                .HasColumnName("delivery_address");
            entity.Property(e => e.DeliveryTime).HasColumnName("delivery_time");
            entity.Property(e => e.DiscountCode)
                .HasMaxLength(50)
                .HasDefaultValue("50")
                .HasColumnName("discount_code");
            entity.Property(e => e.IsPaid).HasColumnName("is_paid");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasDefaultValue("10")
                .HasColumnName("payment_method");
            entity.Property(e => e.RestaurantIdFk).HasColumnName("restaurant_id_fk");
            entity.Property(e => e.SpecialRequests).HasColumnName("special_requests");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.CustomerIdFkNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerIdFk)
                .HasConstraintName("Orders_fk1");

            entity.HasOne(d => d.RestaurantIdFkNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.RestaurantIdFk)
                .HasConstraintName("Orders_fk2");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PK__OrderIte__3764B6BC2EEB6FEF");

            entity.Property(e => e.OrderItemId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("order_item_id");
            entity.Property(e => e.Allergens)
                .HasMaxLength(255)
                .HasDefaultValue("255")
                .HasColumnName("allergens");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.IsRefunded).HasColumnName("is_refunded");
            entity.Property(e => e.ItemIdFk).HasColumnName("item_id_fk");
            entity.Property(e => e.ItemNotes)
                .HasMaxLength(255)
                .HasColumnName("item_notes");
            entity.Property(e => e.OrderIdFk).HasColumnName("order_id_fk");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SpecialRequests)
                .HasMaxLength(255)
                .HasColumnName("special_requests");
            entity.Property(e => e.SpiceLevel)
                .HasMaxLength(50)
                .HasDefaultValue("10")
                .HasColumnName("spice_level");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.ItemIdFkNavigation).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemIdFk)
                .HasConstraintName("OrderItems_fk4");

            entity.HasOne(d => d.OrderIdFkNavigation).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderIdFk)
                .HasConstraintName("OrderItems_fk3");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__ED1FC9EA4B01BD21");

            entity.Property(e => e.PaymentId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Currency)
                .HasMaxLength(10)
                .HasDefaultValue("VND")
                .HasColumnName("currency");
            entity.Property(e => e.CustomerIdFk).HasColumnName("customer_id_fk");
            entity.Property(e => e.OrderIdFk).HasColumnName("order_id_fk");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasDefaultValue("Credit Card")
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentNotes)
                .HasMaxLength(255)
                .HasColumnName("payment_notes");
            entity.Property(e => e.RefundAmount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("refund_amount");
            entity.Property(e => e.RefundStatus).HasColumnName("refund_status");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasDefaultValue("TRANSACTION123")
                .HasColumnName("transaction_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CustomerIdFkNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CustomerIdFk)
                .HasConstraintName("Payments_fk9");

            entity.HasOne(d => d.OrderIdFkNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderIdFk)
                .HasConstraintName("Payments_fk1");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderId).HasName("PK__Purchase__AFCA88E6FE53C937");

            entity.ToTable("PurchaseOrder");

            entity.Property(e => e.PurchaseOrderId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("purchase_order_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Đang x? l?")
                .HasColumnName("status");
            entity.Property(e => e.SupplierIdFk).HasColumnName("supplier_id_fk");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.SupplierIdFkNavigation).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierIdFk)
                .HasConstraintName("FK__PurchaseO__suppl__18B6AB08");
        });

        modelBuilder.Entity<PurchaseOrderItem>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderItemId).HasName("PK__Purchase__8A902DFA2ACF037A");

            entity.ToTable("PurchaseOrderItem");

            entity.Property(e => e.PurchaseOrderItemId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("purchase_order_item_id");
            entity.Property(e => e.IngredientIdFk).HasColumnName("ingredient_id_fk");
            entity.Property(e => e.PurchaseOrderIdFk).HasColumnName("purchase_order_id_fk");
            entity.Property(e => e.QuantityOrdered)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("quantity_ordered");
            entity.Property(e => e.TotalPrice)
                .HasComputedColumnSql("([quantity_ordered]*[unit_price])", false)
                .HasColumnType("decimal(37, 4)")
                .HasColumnName("total_price");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("unit_price");

            entity.HasOne(d => d.PurchaseOrderIdFkNavigation).WithMany(p => p.PurchaseOrderItems)
                .HasForeignKey(d => d.PurchaseOrderIdFk)
                .HasConstraintName("FK__PurchaseO__purch__214BF109");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__31384C29EE92700D");

            entity.Property(e => e.ReservationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("reservation_id");
            entity.Property(e => e.ConfirmationCode)
                .HasMaxLength(50)
                .HasDefaultValue("CONFIRM123")
                .HasColumnName("confirmation_code");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .HasDefaultValue("0000000000")
                .HasColumnName("contact_number");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CustomerIdFk).HasColumnName("customer_id_fk");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasDefaultValue("example@domain.com")
                .HasColumnName("email");
            entity.Property(e => e.LoyaltyPointsUsed).HasColumnName("loyalty_points_used");
            entity.Property(e => e.NumberOfPeople).HasColumnName("number_of_people");
            entity.Property(e => e.ReservationDate)
                .HasColumnType("datetime")
                .HasColumnName("reservation_date");
            entity.Property(e => e.RestaurantIdFk).HasColumnName("restaurant_id_fk");
            entity.Property(e => e.SpecialRequests)
                .HasMaxLength(255)
                .HasColumnName("special_requests");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TableNumber).HasColumnName("table_number");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CustomerIdFkNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CustomerIdFk)
                .HasConstraintName("Reservations_fk1");

            entity.HasOne(d => d.RestaurantIdFkNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RestaurantIdFk)
                .HasConstraintName("Reservations_fk2");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.RestaurantId).HasName("PK__Restaura__3B0FAA91E16F3D89");

            entity.Property(e => e.RestaurantId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("restaurant_id");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .HasDefaultValue("15")
                .HasColumnName("contact_number");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CuisineType)
                .HasMaxLength(100)
                .HasDefaultValue("100")
                .HasColumnName("cuisine_type");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasDefaultValue("255")
                .HasColumnName("email");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasDefaultValue("255")
                .HasColumnName("location");
            entity.Property(e => e.ManagerIdFk).HasColumnName("manager_id_fk");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasDefaultValue("255")
                .HasColumnName("name");
            entity.Property(e => e.OpeningHours)
                .HasMaxLength(100)
                .HasDefaultValue("100")
                .HasColumnName("opening_hours");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.SeatingCapacity).HasColumnName("seating_capacity");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .HasDefaultValue("255")
                .HasColumnName("website");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__60883D90CFF2FD3D");

            entity.Property(e => e.ReviewId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("review_id");
            entity.Property(e => e.Comment)
                .HasMaxLength(1000)
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CustomerIdFk).HasColumnName("customer_id_fk");
            entity.Property(e => e.HelpfulVotes).HasColumnName("helpful_votes");
            entity.Property(e => e.IsAnonymous).HasColumnName("is_anonymous");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Response)
                .HasMaxLength(1000)
                .HasColumnName("response");
            entity.Property(e => e.ResponseDate)
                .HasColumnType("datetime")
                .HasColumnName("response_date");
            entity.Property(e => e.RestaurantIdFk).HasColumnName("restaurant_id_fk");
            entity.Property(e => e.ReviewType).HasColumnName("review_type");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CustomerIdFkNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerIdFk)
                .HasConstraintName("Reviews_fk6");

            entity.HasOne(d => d.RestaurantIdFkNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.RestaurantIdFk)
                .HasConstraintName("Reviews_fk5");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__1963DD9C48D37BCE");

            entity.Property(e => e.StaffId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("staff_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasDefaultValue("example@domain.com")
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasDefaultValue("John")
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasDefaultValue("Doe")
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasDefaultValue("0000000000")
                .HasColumnName("phone_number");
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(255)
                .HasDefaultValue("default.jpg")
                .HasColumnName("profile_picture");
            entity.Property(e => e.RestaurantIdFk).HasColumnName("restaurant_id_fk");
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .HasDefaultValue("Staff")
                .HasColumnName("role");
            entity.Property(e => e.Salary)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("salary");
            entity.Property(e => e.ShiftEndTime).HasColumnName("shift_end_time");
            entity.Property(e => e.ShiftStartTime).HasColumnName("shift_start_time");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.RestaurantIdFkNavigation).WithMany(p => p.Staff)
                .HasForeignKey(d => d.RestaurantIdFk)
                .HasConstraintName("Staff_fk15");
        });

        modelBuilder.Entity<StaffAttendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__StaffAtt__20D6A96816A1B970");

            entity.ToTable("StaffAttendance");

            entity.Property(e => e.AttendanceId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("attendance_id");
            entity.Property(e => e.AttendanceDate)
                .HasColumnType("datetime")
                .HasColumnName("attendance_date");
            entity.Property(e => e.CheckInTime)
                .HasColumnType("datetime")
                .HasColumnName("check_in_time");
            entity.Property(e => e.CheckOutTime)
                .HasColumnType("datetime")
                .HasColumnName("check_out_time");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.StaffIdFk).HasColumnName("staff_id_fk");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TotalHours)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("total_hours");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.StaffIdFkNavigation).WithMany(p => p.StaffAttendances)
                .HasForeignKey(d => d.StaffIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StaffAtte__staff__59C55456");
        });

        modelBuilder.Entity<StaffLeave>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__StaffLea__743350BC63FB6C86");

            entity.ToTable("StaffLeave");

            entity.Property(e => e.LeaveId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("leave_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.LeaveDate).HasColumnName("leave_date");
            entity.Property(e => e.LeaveReason)
                .HasMaxLength(255)
                .HasColumnName("leave_reason");
            entity.Property(e => e.LeaveType)
                .HasMaxLength(50)
                .HasColumnName("leave_type");
            entity.Property(e => e.StaffIdFk).HasColumnName("staff_id_fk");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.StaffIdFkNavigation).WithMany(p => p.StaffLeaves)
                .HasForeignKey(d => d.StaffIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StaffLeav__staff__5F7E2DAC");
        });

        modelBuilder.Entity<StaffSalary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__StaffSal__A3C71C51C162EE50");

            entity.ToTable("StaffSalary");

            entity.Property(e => e.SalaryId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("salary_id");
            entity.Property(e => e.Allowance)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("allowance");
            entity.Property(e => e.BasicSalary)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("basic_salary");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.NetSalary)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("net_salary");
            entity.Property(e => e.PaymentMonth).HasColumnName("payment_month");
            entity.Property(e => e.StaffIdFk).HasColumnName("staff_id_fk");
            entity.Property(e => e.TotalSalary)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_salary");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.StaffIdFkNavigation).WithMany(p => p.StaffSalaries)
                .HasForeignKey(d => d.StaffIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StaffSala__staff__65370702");
        });

        modelBuilder.Entity<StaffSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__StaffSch__C46A8A6FC364A241");

            entity.ToTable("StaffSchedule");

            entity.Property(e => e.ScheduleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("schedule_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Shift)
                .HasMaxLength(50)
                .HasColumnName("shift");
            entity.Property(e => e.ShiftEndTime)
                .HasColumnType("datetime")
                .HasColumnName("shift_end_time");
            entity.Property(e => e.ShiftStartTime)
                .HasColumnType("datetime")
                .HasColumnName("shift_start_time");
            entity.Property(e => e.StaffIdFk).HasColumnName("staff_id_fk");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.WorkDate).HasColumnName("work_date");

            entity.HasOne(d => d.StaffIdFkNavigation).WithMany(p => p.StaffSchedules)
                .HasForeignKey(d => d.StaffIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StaffSche__staff__540C7B00");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__6EE594E8AAA1CF90");

            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("supplier_id");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Active")
                .HasColumnName("status");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(255)
                .HasColumnName("supplier_name");
            entity.Property(e => e.TaxId)
                .HasMaxLength(50)
                .HasColumnName("tax_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SuppliersContact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Supplier__024E7A8669AACABE");

            entity.Property(e => e.ContactId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("contact_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .HasColumnName("contact_name");
            entity.Property(e => e.ContactTitle)
                .HasMaxLength(100)
                .HasColumnName("contact_title");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DetailedAddress)
                .HasMaxLength(255)
                .HasColumnName("detailed_address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.SupplierIdFk).HasColumnName("supplier_id_fk");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.SupplierIdFkNavigation).WithMany(p => p.SuppliersContacts)
                .HasForeignKey(d => d.SupplierIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Supplier_Contact");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.TableId).HasName("PK__Tables__B21E8F244A91D0F0");

            entity.Property(e => e.TableId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("table_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IsReserved).HasColumnName("is_reserved");
            entity.Property(e => e.LastReservedAt)
                .HasColumnType("datetime")
                .HasColumnName("last_reserved_at");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.ReservationIdFk).HasColumnName("reservation_id_fk");
            entity.Property(e => e.RestaurantIdFk).HasColumnName("restaurant_id_fk");
            entity.Property(e => e.SeatingCapacity).HasColumnName("seating_capacity");
            entity.Property(e => e.SpecialRequests)
                .HasMaxLength(500)
                .HasColumnName("special_requests");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TableNumber).HasColumnName("table_number");
            entity.Property(e => e.TableType).HasColumnName("table_type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.RestaurantIdFkNavigation).WithMany(p => p.Tables)
                .HasForeignKey(d => d.RestaurantIdFk)
                .HasConstraintName("Tables_fk1");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserAcco__B9BE370F2121758F");

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasDefaultValue("email@example.com")
                .HasColumnName("email");
            entity.Property(e => e.LastLogin)
                .HasColumnType("datetime")
                .HasColumnName("last_login");
            entity.Property(e => e.LastPasswordChange)
                .HasColumnType("datetime")
                .HasColumnName("last_password_change");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasDefaultValue("hashed_password")
                .HasColumnName("password_hash");
            entity.Property(e => e.Preferences).HasColumnName("preferences");
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(255)
                .HasDefaultValue("profile.jpg")
                .HasColumnName("profile_picture");
            entity.Property(e => e.RoleIdFk).HasColumnName("Role_ID_FK");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TwoFactorEnabled).HasColumnName("two_factor_enabled");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasDefaultValue("user")
                .HasColumnName("username");

            entity.HasOne(d => d.RoleIdFkNavigation).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.RoleIdFk)
                .HasConstraintName("FK_Role_User");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC2716256A18");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newsequentialid())")
                .HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
