namespace EFCodeFirst.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class DefaultContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“DefaultContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“EFCodeFirst.EF.DefaultContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DefaultContext”
        //连接字符串。
        public DefaultContext()
            : base("name=DefaultContext")
        {
        }

        public virtual DbSet<Att> Atts { get; set; }
        public virtual DbSet<Other> Others { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new DropCreateIfChangeInitializer());   //实现CreateDatabaseIfNotExists时可以注释此行，CodeFirst默认为CreateDatabaseIfNotExists方式

            modelBuilder.Entity<Other>()
               .Property(e => e.Id)
               .IsUnicode(false);

            modelBuilder.Entity<Other>()
                .Property(e => e.Content)
                .IsUnicode(false);
        }
    }

    /// <summary>
    /// Create if not exist , Code first默认行为
    /// </summary>
    public class CreateIfNotExistsInitializer : CreateDatabaseIfNotExists<DefaultContext>
    {
        protected override void Seed(DefaultContext context)
        {
            //测试增加种子数据
            //context.Others.Add(new Other() { Id = Math.Abs(Guid.NewGuid().GetHashCode()).ToString() });
            base.Seed(context);
        }
    }

    /// <summary>
    /// Create after drop if change
    /// </summary>
    public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<DefaultContext>
    {
        protected override void Seed(DefaultContext context)
        {
            //测试增加种子数据
            //context.Others.Add(new Other() { Id = Math.Abs(Guid.NewGuid().GetHashCode()).ToString() });
            base.Seed(context);
        }
    }
}