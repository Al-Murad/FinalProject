using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APSS.Api.Models
{

    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        [Required(ErrorMessage = "VehicleTypeName is required"),StringLength(50)]
        public string VehicleTypeName { get; set; } = default!;

        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
        public virtual ICollection<ServiceType> ServiceTypes { get; set; } = new List<ServiceType>();


    }
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        [Required(ErrorMessage = "ProductCategoryName is required"), StringLength(50)]
        public string ProductCategoryName { get; set; } = default!;
        [Required,ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }
        public virtual VehicleType? VehicleType { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "ProductName is required"), StringLength(50),Display(Name = "Product Name")]
        public string ProductName { get; set; } = default!;
        [Required,Column(TypeName ="money"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0.00")]
        public decimal Price { get; set; }
        [Required, StringLength(100)]
        public string ShortDescription { get; set; } = default!;
        [Required, ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual ICollection<ProductPicture> ProductPictures { get; set; } = new List<ProductPicture>();
        public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
    }
    public class ProductPicture
    {
        public int ProductPictureId { get; set; }
        [Required(ErrorMessage ="Picture is required"), StringLength(50)]
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
        public string Description { get; set; } = default!;
        [Required, Column(TypeName = "date"),DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="yyyy-MM-dd")]
        public DateTime RequestDate { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-dd")]

        public DateTime ProposedServiceDate { get; set; }
        [Required, StringLength(50)]
        public string CustomerName { get; set; } = default!;
        [Required, StringLength(50)]
        public string Phone { get; set; } = default!;
        [Required, StringLength(50)]
        public string Email { get; set; } = default!;
        [Required, ForeignKey("ServiceType")]
        public int ServiceTypeId { get; set; }
        public virtual ServiceType? ServiceType { get; set; }
        public virtual ICollection<Service>Services { get; set; }=new List<Service>();
    }
    public class Service
    {
        public int ServiceId { get; set; }
        [Required, StringLength(50)]
        public string ServiceDetails { get; set; } = default!;
        [Required, Column(TypeName = "money")]
        public decimal ServiceCost { get; set; }
        [Required, ForeignKey("ServiceRequest")]
        public int ServiceRequestId { get; set; }
        public virtual ServiceRequest? ServiceRequest { get; set; }

        [Required, ForeignKey("ServiceStatus")]
        public int ServiceStatusId { get; set; }
        public virtual ServiceStatus? ServiceStatus { get; set; }

        public virtual ICollection<Part> Parts { get; set; }=new List<Part>();
        public virtual ICollection<ServicePayment>ServicePayments { get; set; }=new List<ServicePayment>();
    }
    public class Part
    {
        public int PartId { get; set;}
        [Required, StringLength(50)]
        public string PartName { get; set; }=default!;
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required, ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Service? Service { get; set; }
    }
    public class ServiceStatus
    {
        public int ServiceStatusId { get; set; }
        [Required,StringLength(50)]
        public string StatusName {  get; set; }=default!;
        public virtual ICollection<Service> Services { get; set; }=new List<Service>();
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
        [Required, ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual Service? Service { get; set; }
    }
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
        public DbSet<Service> Services { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ServiceStatus> ServiceStatus { get; set; }
        public DbSet<ServicePayment> ServicePayments { get; set; }
        
    }
}