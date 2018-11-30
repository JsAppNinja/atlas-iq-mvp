using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using static AtlasIQMVP.DataAccessLayer.Extensions;

namespace AtlasIQMVP.WebAPI.DataAccess.Models
{
    public partial class cms_TVAContext : DbContext
    {
        public cms_TVAContext()
        {
        }

        public cms_TVAContext(DbContextOptions<cms_TVAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CcicmsReferenceItems> CcicmsReferenceItems { get; set; }
        public virtual DbSet<CcicmsReferenceListItems> CcicmsReferenceListItems { get; set; }
        public virtual DbSet<CcicmsReferenceLists> CcicmsReferenceLists { get; set; }
        public virtual DbSet<ProspectPortalRealEstate> ProspectPortalRealEstate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var setting = ConfigHelper.GetConfig();
                var connectionstring = setting["DefaultConnection"];
                optionsBuilder.UseSqlServer(connectionstring);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-preview3-35497");

            modelBuilder.Entity<CcicmsReferenceItems>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__ccicms_R__3214EC265E54FF49")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ccicms_ReferenceItems");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_refitemsId")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Copyright)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Owner)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Path).IsUnicode(false);

                entity.Property(e => e.Thumbnail).IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CcicmsReferenceListItems>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__ccicms_R__3214EC26640DD89F")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ccicms_ReferenceListItems");

                entity.HasIndex(e => new { e.ListId, e.ItemId })
                    .HasName("IX_refListItems_ListItemId")
                    .ForSqlServerIsClustered();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ListId).HasColumnName("ListID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");
            });

            modelBuilder.Entity<CcicmsReferenceLists>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__ccicms_R__3214EC2661316BF4")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ccicms_ReferenceLists");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_refLists_Id");

                entity.HasIndex(e => e.OwnerId)
                    .HasName("IX_refLists_OwnerIdType")
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.Name, e.OwnerType, e.OwnerId })
                    .HasName("IX_ReferenceLists_NameOwnerTypeId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.OwnerType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProspectPortalRealEstate>(entity =>
            {
                entity.ToTable("ProspectPortal_RealEstate");

                entity.HasIndex(e => e.Address1)
                    .HasName("IX_Address");

                entity.HasIndex(e => e.Available)
                    .HasName("IX_Available");

                entity.HasIndex(e => e.City)
                    .HasName("IX_City");

                entity.HasIndex(e => e.County)
                    .HasName("IX_County");

                entity.HasIndex(e => e.Dataqualityscore)
                    .HasName("IX_DataQualityScore");

                entity.HasIndex(e => e.Name)
                    .HasName("IX_Name");

                entity.HasIndex(e => e.Status)
                    .HasName("IX_Status");

                entity.HasIndex(e => e.Type)
                    .HasName("IX_Type");

                entity.HasIndex(e => e.Updated)
                    .HasName("idx_updated");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Addlacreageavail)
                    .HasColumnName("addlacreageavail")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Address1)
                    .HasColumnName("address1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Airconditioned)
                    .HasColumnName("airconditioned")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Airport)
                    .HasColumnName("airport")
                    .IsUnicode(false);

                entity.Property(e => e.Airportzone).HasColumnName("airportzone");

                entity.Property(e => e.Airportzonename)
                    .HasColumnName("airportzonename")
                    .IsUnicode(false);

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.Baylength).HasColumnName("baylength");

                entity.Property(e => e.Baywidth).HasColumnName("baywidth");

                entity.Property(e => e.Brokeraddress1)
                    .HasColumnName("brokeraddress1")
                    .IsUnicode(false);

                entity.Property(e => e.Brokeraddress2)
                    .HasColumnName("brokeraddress2")
                    .IsUnicode(false);

                entity.Property(e => e.Brokercellphone)
                    .HasColumnName("brokercellphone")
                    .IsUnicode(false);

                entity.Property(e => e.Brokercity)
                    .HasColumnName("brokercity")
                    .IsUnicode(false);

                entity.Property(e => e.Brokercompany)
                    .HasColumnName("brokercompany")
                    .IsUnicode(false);

                entity.Property(e => e.Brokeremail)
                    .HasColumnName("brokeremail")
                    .IsUnicode(false);

                entity.Property(e => e.Brokerfax)
                    .HasColumnName("brokerfax")
                    .IsUnicode(false);

                entity.Property(e => e.Brokerfirstname)
                    .HasColumnName("brokerfirstname")
                    .IsUnicode(false);

                entity.Property(e => e.Brokerlastname)
                    .HasColumnName("brokerlastname")
                    .IsUnicode(false);

                entity.Property(e => e.Brokerphone)
                    .HasColumnName("brokerphone")
                    .IsUnicode(false);

                entity.Property(e => e.Brokerstate)
                    .HasColumnName("brokerstate")
                    .IsUnicode(false);

                entity.Property(e => e.Brokerwebsite)
                    .HasColumnName("brokerwebsite")
                    .IsUnicode(false);

                entity.Property(e => e.Brokerzip)
                    .HasColumnName("brokerzip")
                    .IsUnicode(false);

                entity.Property(e => e.Brownfield).HasMaxLength(100);

                entity.Property(e => e.BuildableAcres)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingDimensions).HasMaxLength(100);

                entity.Property(e => e.Buildingname)
                    .HasColumnName("buildingname")
                    .IsUnicode(false);

                entity.Property(e => e.Buildingsize).HasColumnName("buildingsize");

                entity.Property(e => e.Buildingtype)
                    .HasColumnName("buildingtype")
                    .IsUnicode(false);

                entity.Property(e => e.Businesspark)
                    .HasColumnName("businesspark")
                    .IsUnicode(false);

                entity.Property(e => e.CallCenter)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CapacityOfLargestBridgeCrane).HasMaxLength(100);

                entity.Property(e => e.Ceilingmax).HasColumnName("ceilingmax");

                entity.Property(e => e.Ceilingmin).HasColumnName("ceilingmin");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Citylimits).HasColumnName("citylimits");

                entity.Property(e => e.ColumnSpacing)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Constructionmaterial)
                    .HasColumnName("constructionmaterial")
                    .IsUnicode(false);

                entity.Property(e => e.Constructionmaterialsecondary)
                    .HasColumnName("constructionmaterialsecondary")
                    .IsUnicode(false);

                entity.Property(e => e.Contactid).HasColumnName("contactid");

                entity.Property(e => e.Contiguous).HasColumnName("contiguous");

                entity.Property(e => e.ContiguousAcresAvailableForDevelopment).HasMaxLength(100);

                entity.Property(e => e.County)
                    .HasColumnName("county")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cranesunderhook)
                    .HasColumnName("cranesunderhook")
                    .HasMaxLength(50);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.CreatedbyApc)
                    .HasColumnName("createdby_APC")
                    .HasMaxLength(10);

                entity.Property(e => e.Currentprevioususe)
                    .HasColumnName("currentprevioususe")
                    .IsUnicode(false);

                entity.Property(e => e.DataCenter)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Databankid)
                    .HasColumnName("databankid")
                    .IsUnicode(false);

                entity.Property(e => e.Dataqualityscore).HasColumnName("dataqualityscore");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Distanceairport).HasColumnName("distanceairport");

                entity.Property(e => e.Distancehighway).HasColumnName("distancehighway");

                entity.Property(e => e.Distanceinterstate).HasColumnName("distanceinterstate");

                entity.Property(e => e.Distanceport).HasColumnName("distanceport");

                entity.Property(e => e.Distancerail).HasColumnName("distancerail");

                entity.Property(e => e.DistancerailApc).HasColumnName("distancerail_APC");

                entity.Property(e => e.Divisible).HasColumnName("divisible");

                entity.Property(e => e.Divisiblefrom).HasColumnName("divisiblefrom");

                entity.Property(e => e.Dockhigh).HasColumnName("dockhigh");

                entity.Property(e => e.Dockslevel).HasColumnName("dockslevel");

                entity.Property(e => e.Drivein).HasColumnName("drivein");

                entity.Property(e => e.Dslavailable)
                    .HasColumnName("dslavailable")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Edaddress1)
                    .HasColumnName("edaddress1")
                    .IsUnicode(false);

                entity.Property(e => e.Edaddress2)
                    .HasColumnName("edaddress2")
                    .IsUnicode(false);

                entity.Property(e => e.Edcellphone)
                    .HasColumnName("edcellphone")
                    .IsUnicode(false);

                entity.Property(e => e.Edcity)
                    .HasColumnName("edcity")
                    .IsUnicode(false);

                entity.Property(e => e.Edcompany)
                    .HasColumnName("edcompany")
                    .IsUnicode(false);

                entity.Property(e => e.Edcontactid).HasColumnName("edcontactid");

                entity.Property(e => e.Edemail)
                    .HasColumnName("edemail")
                    .IsUnicode(false);

                entity.Property(e => e.Edfax)
                    .HasColumnName("edfax")
                    .IsUnicode(false);

                entity.Property(e => e.Edfirstname)
                    .HasColumnName("edfirstname")
                    .IsUnicode(false);

                entity.Property(e => e.Edlastname)
                    .HasColumnName("edlastname")
                    .IsUnicode(false);

                entity.Property(e => e.Edphone)
                    .HasColumnName("edphone")
                    .IsUnicode(false);

                entity.Property(e => e.Edstate)
                    .HasColumnName("edstate")
                    .IsUnicode(false);

                entity.Property(e => e.Edwebsite)
                    .HasColumnName("edwebsite")
                    .IsUnicode(false);

                entity.Property(e => e.Edzip)
                    .HasColumnName("edzip")
                    .IsUnicode(false);

                entity.Property(e => e.Electric)
                    .HasColumnName("electric")
                    .IsUnicode(false);

                entity.Property(e => e.Electricamps).HasColumnName("electricamps");

                entity.Property(e => e.Electricphase).HasColumnName("electricphase");

                entity.Property(e => e.Electricvolts)
                    .HasColumnName("electricvolts")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Enterprisezone).HasColumnName("enterprisezone");

                entity.Property(e => e.Expandabletosf)
                    .HasColumnName("expandabletosf")
                    .HasMaxLength(50);

                entity.Property(e => e.Expandableyesno).HasColumnName("expandableyesno");

                entity.Property(e => e.Expansiondate)
                    .HasColumnName("expansiondate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Featured).HasColumnName("featured");

                entity.Property(e => e.FeaturedLabel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Featuredsecondary).HasColumnName("featuredsecondary");

                entity.Property(e => e.Fiber)
                    .HasColumnName("fiber")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Floodplain).HasColumnName("floodplain");

                entity.Property(e => e.Floorthickness).HasColumnName("floorthickness");

                entity.Property(e => e.Forlease).HasColumnName("forlease");

                entity.Property(e => e.Forsale).HasColumnName("forsale");

                entity.Property(e => e.FreightElevator).HasMaxLength(100);

                entity.Property(e => e.Gas)
                    .HasColumnName("gas")
                    .IsUnicode(false);

                entity.Property(e => e.Gasmainsize).HasColumnName("gasmainsize");

                entity.Property(e => e.Gasonsite).HasColumnName("gasonsite");

                entity.Property(e => e.Gaspsi).HasColumnName("gaspsi");

                entity.Property(e => e.HeatType)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Heated)
                    .HasColumnName("heated")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Highway)
                    .HasColumnName("highway")
                    .IsUnicode(false);

                entity.Property(e => e.Imageimport)
                    .HasColumnName("imageimport")
                    .IsUnicode(false);

                entity.Property(e => e.Interstate)
                    .HasColumnName("interstate")
                    .IsUnicode(false);

                entity.Property(e => e.IsContiguous).HasColumnName("isContiguous");

                entity.Property(e => e.IsOpportunityZone).HasColumnName("isOpportunityZone");

                entity.Property(e => e.Israil).HasColumnName("israil");

                entity.Property(e => e.Kva)
                    .HasColumnName("KVA")
                    .HasMaxLength(100);

                entity.Property(e => e.Landtype)
                    .HasColumnName("landtype")
                    .IsUnicode(false);

                entity.Property(e => e.LastImportDate).HasColumnType("datetime");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Leasecost).HasColumnName("leasecost");

                entity.Property(e => e.Leasetype)
                    .HasColumnName("leasetype")
                    .IsUnicode(false);

                entity.Property(e => e.Loadbearing)
                    .HasColumnName("loadbearing")
                    .IsUnicode(false);

                entity.Property(e => e.Lon).HasColumnName("lon");

                entity.Property(e => e.Multitenant).HasColumnName("multitenant");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Networked).HasColumnName("networked");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .IsUnicode(false);

                entity.Property(e => e.Numbertruckdocks).HasColumnName("numbertruckdocks");

                entity.Property(e => e.Officeareasf).HasColumnName("officeareasf");

                entity.Property(e => e.Overrideimport)
                    .HasColumnName("overrideimport")
                    .IsUnicode(false);

                entity.Property(e => e.Ownership)
                    .HasColumnName("ownership")
                    .IsUnicode(false);

                entity.Property(e => e.Parcelid)
                    .HasColumnName("parcelid")
                    .IsUnicode(false);

                entity.Property(e => e.Parentid)
                    .HasColumnName("parentid")
                    .IsUnicode(false);

                entity.Property(e => e.Parking).HasColumnName("parking");

                entity.Property(e => e.ParkingApc).HasColumnName("parking_APC");

                entity.Property(e => e.Parkingpaved)
                    .HasColumnName("parkingpaved")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Parkingratio)
                    .HasColumnName("parkingratio")
                    .IsUnicode(false);

                entity.Property(e => e.Phase1)
                    .HasColumnName("phase1")
                    .IsUnicode(false);

                entity.Property(e => e.Photoindicator).HasColumnName("photoindicator");

                entity.Property(e => e.Port)
                    .HasColumnName("port")
                    .IsUnicode(false);

                entity.Property(e => e.Poweronsite).HasColumnName("poweronsite");

                entity.Property(e => e.Previoustenant)
                    .HasColumnName("previoustenant")
                    .IsUnicode(false);

                entity.Property(e => e.Pricenegotiable)
                    .HasColumnName("pricenegotiable")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Pricepersf).HasColumnName("pricepersf");

                entity.Property(e => e.Providerid).HasColumnName("providerid");

                entity.Property(e => e.ProximityToSubstation).HasMaxLength(100);

                entity.Property(e => e.Rail)
                    .HasColumnName("rail")
                    .IsUnicode(false);

                entity.Property(e => e.Rail2distance)
                    .HasColumnName("rail2distance")
                    .IsUnicode(false);

                entity.Property(e => e.Refrigeratedsf)
                    .HasColumnName("refrigeratedsf")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReinforcedConcreteFloor).HasMaxLength(100);

                entity.Property(e => e.Rentalrateannual)
                    .HasColumnName("rentalrateannual")
                    .HasMaxLength(50);

                entity.Property(e => e.Responsible)
                    .HasColumnName("responsible")
                    .IsUnicode(false);

                entity.Property(e => e.Revitalizationarea).HasColumnName("revitalizationarea");

                entity.Property(e => e.Saleprice).HasColumnName("saleprice");

                entity.Property(e => e.Salepriceunits)
                    .HasColumnName("salepriceunits")
                    .IsUnicode(false);

                entity.Property(e => e.Secondrail)
                    .HasColumnName("secondrail")
                    .IsUnicode(false);

                entity.Property(e => e.Sewer)
                    .HasColumnName("sewer")
                    .IsUnicode(false);

                entity.Property(e => e.Sewermainsize).HasColumnName("sewermainsize");

                entity.Property(e => e.Seweronsite).HasColumnName("seweronsite");

                entity.Property(e => e.Shovelready).HasColumnName("shovelready");

                entity.Property(e => e.Sitesize).HasColumnName("sitesize");

                entity.Property(e => e.SprinklerType)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Sprinklered).HasColumnName("sprinklered");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Streetview)
                    .HasColumnName("streetview")
                    .IsUnicode(false);

                entity.Property(e => e.Subclassification)
                    .HasColumnName("subclassification")
                    .IsUnicode(false);

                entity.Property(e => e.Suite)
                    .HasColumnName("suite")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telecom)
                    .HasColumnName("telecom")
                    .IsUnicode(false);

                entity.Property(e => e.Telecomonsite).HasColumnName("telecomonsite");

                entity.Property(e => e.Tif).HasColumnName("tif");

                entity.Property(e => e.Topography)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Tradezone).HasColumnName("tradezone");

                entity.Property(e => e.Truckdocks).HasColumnName("truckdocks");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("datetime");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.WarehouseSf).HasColumnName("WarehouseSF");

                entity.Property(e => e.WasteWaterExcessCapacity).HasMaxLength(100);

                entity.Property(e => e.Water)
                    .HasColumnName("water")
                    .IsUnicode(false);

                entity.Property(e => e.WaterExcessCapacity).HasMaxLength(100);

                entity.Property(e => e.Watermainsize).HasColumnName("watermainsize");

                entity.Property(e => e.Wateronsite).HasColumnName("wateronsite");

                entity.Property(e => e.Wetlands)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Yearbuilt).HasColumnName("yearbuilt");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Zoning)
                    .HasColumnName("zoning")
                    .IsUnicode(false);
            });
        }
    }
}
