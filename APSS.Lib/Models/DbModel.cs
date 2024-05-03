using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSS.Lib.Models
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        [Required(ErrorMessage = "VehicleTypeName is required"), StringLength(50)]
        public string VehicleTypeName { get; set; } = default!;

        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        public virtual ICollection<ServiceType> ServiceTypes { get; set; } = new List<ServiceType>();


    }
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        [Required(ErrorMessage = "ProductCategoryName is required"), StringLength(50)]
        public string ProductCategoryName { get; set; } = default!;
        [Required, ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }
        public virtual VehicleType? VehicleType { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "ProductName is required"), StringLength(50), Display(Name = "Product Name")]
        public string ProductName { get; set; } = default!;
        [Required, Column(TypeName = "money"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0.00")]
        public decimal Price { get; set; }
        [Required, StringLength(100)]
        public string ShortDescription { get; set; } = default!;
        [Required, ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual ICollection<ProductPicture> ProductPictures { get; set; } = new List<ProductPicture>();
        public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

        //
        public virtual StockEntry? StockEntry { get; set; }
    }
    public class ProductPicture
    {
        public int ProductPictureId { get; set; }
        [Required(ErrorMessage = "Picture is required"), StringLength(50)]
        public string Picture { get; set; } = default!;
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }


    }
    public class ProductDetail
    {
        public int ProductDetailId { get; set; }
        [StringLength(50)]
        public string? Label { get; set; } = default!;
        [StringLength(50)]
        public string? Value { get; set; } = default!;
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

    }
    public class CommonDetail
    {
        public int CommonDetailId { get; set; }
        [Required(ErrorMessage = "DetailName is required"), StringLength(50)]
        public string DetailName { get; set; } = default!;

    }
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }
        [Required, StringLength(50)]
        public string ServiceName { get; set; } = default!;
        [Required, ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }
        public virtual VehicleType? VehicleType { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();
    }

    public class ServiceRequest
    {
        public int ServiceRequestId { get; set; }
        [Required, StringLength(50)]
        public string CustomerName { get; set; } = default!;
        [Required, StringLength(50)]
        public string Phone { get; set; } = default!;
        [Required, StringLength(50)]
        public string Email { get; set; } = default!;
        [Required, ForeignKey("ServiceType")]
        public int ServiceTypeId { get; set; }
        public virtual ServiceType? ServiceType { get; set; }

        public virtual ICollection<ServiceDetailEntry> ServiceDetailEntries { get; set; } = new List<ServiceDetailEntry>();
        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();


    }
    public class ServiceDetail
    {
        public int ServiceDetailId { get; set; }
        [Required, StringLength(50)]
        public string Description { get; set; } = default!;
        [Required, Column(TypeName = "date"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-dd")]
        public DateTime RequestDate { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-dd")]

        public DateTime ProposedServiceDate { get; set; }
        [Required, ForeignKey("ServiceRequest")]

        public int ServiceRequestId { get; set; }
        public virtual ServiceRequest? ServiceRequest { get; set; }
        public virtual ICollection<ServiceDetailEntry> ServiceDetailEntries { get; set; } = new List<ServiceDetailEntry>();

    }

    public class ServiceDetailEntry
    {
        public int ServiceDetailEntryId { get; set; }


        [Required, Column(TypeName = "money")]
        public decimal ServiceCost { get; set; }
        [Required, ForeignKey("ServiceDetail")]
        public int ServiceDetailId { get; set; }
        public virtual ServiceDetail? ServiceDetail { get; set; }

        [Required, ForeignKey("ServiceStatus")]
        public int ServiceStatusId { get; set; }
        public virtual ServiceStatus? ServiceStatus { get; set; }


        public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
        public virtual ICollection<ServicePayment> ServicePayments { get; set; } = new List<ServicePayment>();
    }
    public class Part
    {
        public int PartId { get; set; }
        [Required, StringLength(50)]
        public string PartName { get; set; } = default!;
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required, ForeignKey("ServiceDetailEntry")]
        public int ServiceDetailEntryId { get; set; }
        public virtual ServiceDetailEntry? ServiceDetailEntry { get; set; }
    }
    public class ServiceStatus
    {
        public int ServiceStatusId { get; set; }
        [Required, StringLength(50)]
        public string StatusName { get; set; } = default!;
        public virtual ICollection<ServiceDetailEntry> ServiceDetailEntries { get; set; } = new List<ServiceDetailEntry>();
    }
    public class ServicePayment
    {
        public int ServicePaymentId { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal Amount { get; set; }
        [Required, StringLength(50)]
        public string PaymentThrough { get; set; } = default!;
        [Required, Column(TypeName = "date"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-dd")]

        public DateTime PaymentDate { get; set; }
        [Required, ForeignKey("ServiceDetailEntry")]
        public int ServiceDetailEntryId { get; set; }
        public virtual ServiceDetailEntry? ServiceDetailEntry { get; set; }
    }
    public class Supplier
    {
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "CompanyName is required"), StringLength(50), Display(Name = "Company Name")]
        public string CompanyName { get; set; } = default!;
        [Required(ErrorMessage = "ContactName is required"), StringLength(50), Display(Name = "Contact Name")]
        public string ContactName { get; set; } = default!;
        [Required, StringLength(30)]
        public string ContactNo { get; set; } = default!;
        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    }
    public class Inventory
    {
        public int InventoryId { get; set; }
        [Required, StringLength(50)]
        public string InventoryCode { get; set; } = default!;
        [Required]
        public int Quantity { get; set; }
        [Required, Column(TypeName = "money"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0.00")]
        public decimal UnitPrice { get; set; }
        [Required, Column(TypeName = "money"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0.00")]
        public decimal RetailPrice { get; set; }
        [Required, ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public virtual Supplier? Supplier { get; set; }
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }

    }

    public class StockEntry
    {
        public int StockEntryId { get; set; }
        public int TotalIn { get; set; }
        public int TotalSold { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "CustomerName is required"), StringLength(50), Display(Name = "Customer Name")]

        public string CustomerName { get; set; } = default!;
        [Required(ErrorMessage = "Phone is required"), StringLength(20)]
        public string Phone { get; set; } = default!;
        [Required(ErrorMessage = "Email is required"), StringLength(30)]
        public string Email { get; set; } = default!;
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
    public class Order
    {
        public int OrderId { get; set; }
        [Required, ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-dd")]

        public DateTime OrderDate { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        [Required, ForeignKey("Order")]

        public int OrderId { get; set; }
        [Required, ForeignKey("Product")]

        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }

	//DbContext


    public class AutoPartsDbContext : DbContext
    {
        public AutoPartsDbContext(DbContextOptions<AutoPartsDbContext> options) : base(options) { }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<CommonDetail> CommonDetails { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<ServiceDetail> ServiceDetails { get; set; }
        public DbSet<ServiceDetailEntry> ServiceDetailEntries { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ServiceStatus> ServiceStatus { get; set; }
        public DbSet<ServicePayment> ServicePayments { get; set; }
        public DbSet<StockEntry> StockEntries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.StockEntry)
                .WithOne(s => s.Product)
                .HasForeignKey<StockEntry>(s => s.ProductId);
        }

    }
}
