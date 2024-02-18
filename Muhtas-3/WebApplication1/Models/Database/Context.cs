using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Database
{
    public class Context : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estimate>()
                .HasRequired(e => e.Customer)
                .WithMany(c => c.Estimates)
            .HasForeignKey(e => e.CustomerID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .HasRequired(e => e.Customer)
                .WithMany(c => c.Invoices)
            .HasForeignKey(e => e.CustomerID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subscription>()
                 .HasRequired(e => e.Customer)
                 .WithMany(c => c.subscriptions)
             .HasForeignKey(e => e.CustomerID)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expense>()
                 .HasRequired(e => e.Customer)
                 .WithMany(c => c.Expenses)
             .HasForeignKey(e => e.CustomerID)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<Support>()
                 .HasRequired(e => e.Tag)
                 .WithMany(c => c.Supports)
             .HasForeignKey(e => e.TagID)
             .WillCascadeOnDelete(false);

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Assigned> Assigneds { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Estimate> Estimates { get; set; }
        public DbSet<SaleAgent> SaleAgents { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }
        public DbSet<Subscription> subscriptions { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<SupportStatus> SupportStatuses { get; set; }
        public DbSet<LeadSource> LeadSources { get; set; }
        public DbSet<LeadStatus> LeadStatuses { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }



}