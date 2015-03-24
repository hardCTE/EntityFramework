// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Tests;
using Xunit;

namespace Microsoft.Data.Entity.Relational.Metadata.Tests
{
    public class RelationalBuilderExtensionsTest
    {
        [Fact]
        public void Can_set_column_name_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .ForRelational()
                .Column("Eman");

            var property = modelBuilder.Model.GetEntityType(typeof(Customer)).GetProperty("Name");

            Assert.Equal("Name", property.Name);
            Assert.Equal("Eman", property.Relational().Column);
        }

        [Fact]
        public void Can_set_column_name_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .ForRelational(b => { b.Column("Eman"); });

            var property = modelBuilder.Model.GetEntityType(typeof(Customer)).GetProperty("Name");

            Assert.Equal("Name", property.Name);
            Assert.Equal("Eman", property.Relational().Column);
        }

        [Fact]
        public void Can_set_column_type_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .ForRelational()
                .ColumnType("nvarchar(42)");

            var property = modelBuilder.Model.GetEntityType(typeof(Customer)).GetProperty("Name");

            Assert.Equal("nvarchar(42)", property.Relational().ColumnType);
        }

        [Fact]
        public void Can_set_column_type_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .ForRelational(b => { b.ColumnType("nvarchar(42)"); });

            var property = modelBuilder.Model.GetEntityType(typeof(Customer)).GetProperty("Name");

            Assert.Equal("nvarchar(42)", property.Relational().ColumnType);
        }

        [Fact]
        public void Can_set_column_default_expression_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .ForRelational()
                .DefaultExpression("CherryCoke");

            var property = modelBuilder.Model.GetEntityType(typeof(Customer)).GetProperty("Name");

            Assert.Equal("CherryCoke", property.Relational().DefaultExpression);
        }

        [Fact]
        public void Can_set_column_default_expression_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .ForRelational(b => { b.DefaultExpression("CherryCoke"); });

            var property = modelBuilder.Model.GetEntityType(typeof(Customer)).GetProperty("Name");

            Assert.Equal("CherryCoke", property.Relational().DefaultExpression);
        }

        [Fact]
        public void Can_set_column_default_value_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();
            var guid = new Guid("{3FDFC4F5-AEAB-4D72-9C96-201E004349FA}");

            modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .ForRelational()
                .DefaultValue(guid);

            var property = modelBuilder.Model.GetEntityType(typeof(Customer)).GetProperty("Name");

            Assert.Equal(guid, property.Relational().DefaultValue);
        }

        [Fact]
        public void Can_set_column_default_value_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();
            var guid = new Guid("{3FDFC4F5-AEAB-4D72-9C96-201E004349FA}");

            modelBuilder
                .Entity<Customer>()
                .Property(e => e.Name)
                .ForRelational(b => { b.DefaultValue(guid); });

            var property = modelBuilder.Model.GetEntityType(typeof(Customer)).GetProperty("Name");

            Assert.Equal(guid, property.Relational().DefaultValue);
        }

        [Fact]
        public void Can_set_key_name_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .Key(e => e.Id)
                .ForRelational()
                .Name("KeyLimePie");

            var key = modelBuilder.Model.GetEntityType(typeof(Customer)).GetPrimaryKey();

            Assert.Equal("KeyLimePie", key.Relational().Name);
        }

        [Fact]
        public void Can_set_key_name_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .Key(e => e.Id)
                .ForRelational(b => { b.Name("KeyLimePie"); });

            var key = modelBuilder.Model.GetEntityType(typeof(Customer)).GetPrimaryKey();

            Assert.Equal("KeyLimePie", key.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_many_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>().Collection(e => e.Orders).InverseReference(e => e.Customer)
                .ForRelational()
                .Name("LemonSupreme");

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(Order)).ForeignKeys.Single(fk => fk.PrincipalEntityType.ClrType == typeof(Customer));

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);

            modelBuilder
                .Entity<Customer>().Collection(e => e.Orders).InverseReference(e => e.Customer)
                .ForRelational()
                .Name(null);

            Assert.Null(foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_many_with_FK_specified_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>().Collection(e => e.Orders).InverseReference(e => e.Customer)
                .ForeignKey(e => e.CustomerId)
                .ForRelational()
                .Name("LemonSupreme");

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(Order)).ForeignKeys.Single(fk => fk.PrincipalEntityType.ClrType == typeof(Customer));

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_many_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>().Collection(e => e.Orders).InverseReference(e => e.Customer)
                .ForRelational(b => { b.Name("LemonSupreme"); });

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(Order)).ForeignKeys.Single(fk => fk.PrincipalEntityType.ClrType == typeof(Customer));

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_many_with_FK_specified_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>().Collection(e => e.Orders).InverseReference(e => e.Customer)
                .ForeignKey(e => e.CustomerId)
                .ForRelational(b => { b.Name("LemonSupreme"); });

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(Order)).ForeignKeys.Single(fk => fk.PrincipalEntityType.ClrType == typeof(Customer));

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_many_to_one_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Order>().Reference(e => e.Customer).InverseCollection(e => e.Orders)
                .ForRelational()
                .Name("LemonSupreme");

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(Order)).ForeignKeys.Single(fk => fk.PrincipalEntityType.ClrType == typeof(Customer));

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);

            modelBuilder
                .Entity<Order>().Reference(e => e.Customer).InverseCollection(e => e.Orders)
                .ForRelational()
                .Name(null);

            Assert.Null(foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_many_to_one_with_FK_specified_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Order>().Reference(e => e.Customer).InverseCollection(e => e.Orders)
                .ForeignKey(e => e.CustomerId)
                .ForRelational()
                .Name("LemonSupreme");

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(Order)).ForeignKeys.Single(fk => fk.PrincipalEntityType.ClrType == typeof(Customer));

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_many_to_one_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Order>().Reference(e => e.Customer).InverseCollection(e => e.Orders)
                .ForRelational(b => { b.Name("LemonSupreme"); });

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(Order)).ForeignKeys.Single(fk => fk.PrincipalEntityType.ClrType == typeof(Customer));

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_many_to_one_with_FK_specified_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Order>().Reference(e => e.Customer).InverseCollection(e => e.Orders)
                .ForeignKey(e => e.CustomerId)
                .ForRelational(b => { b.Name("LemonSupreme"); });

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(Order)).ForeignKeys.Single(fk => fk.PrincipalEntityType.ClrType == typeof(Customer));

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_one_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Order>().Reference(e => e.Details).InverseReference(e => e.Order)
                .PrincipalKey<Order>(e => e.OrderId)
                .ForRelational()
                .Name("LemonSupreme");

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(OrderDetails)).ForeignKeys.Single();

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);

            modelBuilder
                .Entity<Order>().Reference(e => e.Details).InverseReference(e => e.Order)
                .ForRelational()
                .Name(null);

            Assert.Null(foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_one_with_FK_specified_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Order>().Reference(e => e.Details).InverseReference(e => e.Order)
                .ForeignKey<OrderDetails>(e => e.Id)
                .ForRelational()
                .Name("LemonSupreme");

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(OrderDetails)).ForeignKeys.Single();

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_one_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Order>().Reference(e => e.Details).InverseReference(e => e.Order)
                .PrincipalKey<Order>(e => e.OrderId)
                .ForRelational(b => { b.Name("LemonSupreme"); });

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(OrderDetails)).ForeignKeys.Single();

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_foreign_key_name_for_one_to_one_with_FK_specified_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Order>().Reference(e => e.Details).InverseReference(e => e.Order)
                .ForeignKey<OrderDetails>(e => e.Id)
                .ForRelational(b => { b.Name("LemonSupreme"); });

            var foreignKey = modelBuilder.Model.GetEntityType(typeof(OrderDetails)).ForeignKeys.Single();

            Assert.Equal("LemonSupreme", foreignKey.Relational().Name);
        }

        [Fact]
        public void Can_set_index_name_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .Index(e => e.Id)
                .ForRelational()
                .Name("Eeeendeeex");

            var index = modelBuilder.Model.GetEntityType(typeof(Customer)).Indexes.Single();

            Assert.Equal("Eeeendeeex", index.Relational().Name);
        }

        [Fact]
        public void Can_set_index_name_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .Index(e => e.Id)
                .ForRelational(b => { b.Name("Eeeendeeex"); });

            var index = modelBuilder.Model.GetEntityType(typeof(Customer)).Indexes.Single();

            Assert.Equal("Eeeendeeex", index.Relational().Name);
        }

        [Fact]
        public void Can_set_table_name_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .ForRelational()
                .Table("Customizer");

            var entityType = modelBuilder.Model.GetEntityType(typeof(Customer));

            Assert.Equal("Customer", entityType.DisplayName());
            Assert.Equal("Customizer", entityType.Relational().Table);
        }

        [Fact]
        public void Can_set_table_name_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .ForRelational(b => { b.Table("Customizer"); });

            var entityType = modelBuilder.Model.GetEntityType(typeof(Customer));

            Assert.Equal("Customer", entityType.DisplayName());
            Assert.Equal("Customizer", entityType.Relational().Table);
        }

        [Fact]
        public void Can_set_table_name_with_convention_builder_non_generic()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity(typeof(Customer))
                .ForRelational()
                .Table("Customizer");

            var entityType = modelBuilder.Model.GetEntityType(typeof(Customer));

            Assert.Equal("Customer", entityType.DisplayName());
            Assert.Equal("Customizer", entityType.Relational().Table);
        }

        [Fact]
        public void Can_set_table_name_with_convention_builder_using_nested_closure_non_generic()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity(typeof(Customer))
                .ForRelational(b => { b.Table("Customizer"); });

            var entityType = modelBuilder.Model.GetEntityType(typeof(Customer));

            Assert.Equal("Customer", entityType.DisplayName());
            Assert.Equal("Customizer", entityType.Relational().Table);
        }

        [Fact]
        public void Can_set_table_and_schema_name_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .ForRelational()
                .Table("Customizer", "db0");

            var entityType = modelBuilder.Model.GetEntityType(typeof(Customer));

            Assert.Equal("Customer", entityType.DisplayName());
            Assert.Equal("Customizer", entityType.Relational().Table);
            Assert.Equal("db0", entityType.Relational().Schema);
        }

        [Fact]
        public void Can_set_table_and_schema_name_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity<Customer>()
                .ForRelational(b => { b.Table("Customizer", "db0"); });

            var entityType = modelBuilder.Model.GetEntityType(typeof(Customer));

            Assert.Equal("Customer", entityType.DisplayName());
            Assert.Equal("Customizer", entityType.Relational().Table);
            Assert.Equal("db0", entityType.Relational().Schema);
        }

        [Fact]
        public void Can_set_table_and_schema_name_with_convention_builder_non_generic()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity(typeof(Customer))
                .ForRelational()
                .Table("Customizer", "db0");

            var entityType = modelBuilder.Model.GetEntityType(typeof(Customer));

            Assert.Equal("Customer", entityType.DisplayName());
            Assert.Equal("Customizer", entityType.Relational().Table);
            Assert.Equal("db0", entityType.Relational().Schema);
        }

        [Fact]
        public void Can_set_table_and_schema_name_with_convention_builder_using_nested_closure_non_generic()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .Entity(typeof(Customer))
                .ForRelational(b => { b.Table("Customizer", "db0"); });

            var entityType = modelBuilder.Model.GetEntityType(typeof(Customer));

            Assert.Equal("Customer", entityType.DisplayName());
            Assert.Equal("Customizer", entityType.Relational().Table);
            Assert.Equal("db0", entityType.Relational().Schema);
        }

        [Fact]
        public void Can_create_default_sequence_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational()
                .Sequence();

            var sequence = modelBuilder.Model.Relational().TryGetSequence(Sequence.DefaultName);

            ValidateDefaultSequence(sequence);
        }

        [Fact]
        public void Can_create_default_sequence_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational(b => { b.Sequence(); });

            var sequence = modelBuilder.Model.Relational().TryGetSequence(Sequence.DefaultName);

            ValidateDefaultSequence(sequence);
        }

        private static void ValidateDefaultSequence(Sequence sequence)
        {
            Assert.Equal(Sequence.DefaultName, sequence.Name);
            Assert.Null(sequence.Schema);
            Assert.Equal(Sequence.DefaultIncrement, sequence.IncrementBy);
            Assert.Equal(Sequence.DefaultStartValue, sequence.StartValue);
            Assert.Null(sequence.MinValue);
            Assert.Null(sequence.MaxValue);
            Assert.Same(Sequence.DefaultType, sequence.Type);
        }

        [Fact]
        public void Can_create_named_sequence_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational()
                .Sequence("Snook");

            var sequence = modelBuilder.Model.Relational().TryGetSequence("Snook");

            ValidateNamedSequence(sequence);
        }

        [Fact]
        public void Can_create_named_sequence_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational(b => { b.Sequence("Snook"); });

            var sequence = modelBuilder.Model.Relational().TryGetSequence("Snook");

            ValidateNamedSequence(sequence);
        }

        private static void ValidateNamedSequence(Sequence sequence)
        {
            Assert.Equal("Snook", sequence.Name);
            Assert.Null(sequence.Schema);
            Assert.Equal(Sequence.DefaultIncrement, sequence.IncrementBy);
            Assert.Equal(Sequence.DefaultStartValue, sequence.StartValue);
            Assert.Null(sequence.MinValue);
            Assert.Null(sequence.MaxValue);
            Assert.Same(Sequence.DefaultType, sequence.Type);
        }

        [Fact]
        public void Can_create_schema_named_sequence_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational()
                .Sequence("Snook", "Tasty");

            var sequence = modelBuilder.Model.Relational().TryGetSequence("Snook", "Tasty");

            ValidateSchemaNamedSequence(sequence);
        }

        [Fact]
        public void Can_create_schema_named_sequence_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational(b => { b.Sequence("Snook", "Tasty"); });

            var sequence = modelBuilder.Model.Relational().TryGetSequence("Snook", "Tasty");

            ValidateSchemaNamedSequence(sequence);
        }

        private static void ValidateSchemaNamedSequence(Sequence sequence)
        {
            Assert.Equal("Snook", sequence.Name);
            Assert.Equal("Tasty", sequence.Schema);
            Assert.Equal(Sequence.DefaultIncrement, sequence.IncrementBy);
            Assert.Equal(Sequence.DefaultStartValue, sequence.StartValue);
            Assert.Null(sequence.MinValue);
            Assert.Null(sequence.MaxValue);
            Assert.Same(Sequence.DefaultType, sequence.Type);
        }

        [Fact]
        public void Can_create_default_sequence_with_specific_facets_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational()
                .Sequence()
                .IncrementBy(11)
                .Start(1729)
                .Min(111)
                .Max(2222)
                .Type<int>();

            var sequence = modelBuilder.Model.Relational().TryGetSequence(Sequence.DefaultName);

            ValidateDefaultSpecificSequence(sequence);
        }

        [Fact]
        public void Can_create_default_sequence_with_specific_facets_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational(b =>
                    {
                        b.Sequence()
                            .IncrementBy(11)
                            .Start(1729)
                            .Min(111)
                            .Max(2222)
                            .Type<int>();
                    });

            var sequence = modelBuilder.Model.Relational().TryGetSequence(Sequence.DefaultName);

            ValidateDefaultSpecificSequence(sequence);
        }

        private static void ValidateDefaultSpecificSequence(Sequence sequence)
        {
            Assert.Equal(Sequence.DefaultName, sequence.Name);
            Assert.Null(sequence.Schema);
            Assert.Equal(11, sequence.IncrementBy);
            Assert.Equal(1729, sequence.StartValue);
            Assert.Equal(111, sequence.MinValue);
            Assert.Equal(2222, sequence.MaxValue);
            Assert.Same(typeof(int), sequence.Type);
        }

        [Fact]
        public void Can_create_named_sequence_with_specific_facets_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational()
                .Sequence("Snook")
                .IncrementBy(11)
                .Start(1729)
                .Min(111)
                .Max(2222)
                .Type<int>();

            var sequence = modelBuilder.Model.Relational().TryGetSequence("Snook");

            ValidateNamedSpecificSequence(sequence);
        }

        [Fact]
        public void Can_create_named_sequence_with_specific_facets_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational(b =>
                    {
                        b.Sequence("Snook")
                            .IncrementBy(11)
                            .Start(1729)
                            .Min(111)
                            .Max(2222)
                            .Type<int>();
                    });

            var sequence = modelBuilder.Model.Relational().TryGetSequence("Snook");

            ValidateNamedSpecificSequence(sequence);
        }

        private static void ValidateNamedSpecificSequence(Sequence sequence)
        {
            Assert.Equal("Snook", sequence.Name);
            Assert.Null(sequence.Schema);
            Assert.Equal(11, sequence.IncrementBy);
            Assert.Equal(1729, sequence.StartValue);
            Assert.Equal(111, sequence.MinValue);
            Assert.Equal(2222, sequence.MaxValue);
            Assert.Same(typeof(int), sequence.Type);
        }

        [Fact]
        public void Can_create_schema_named_sequence_with_specific_facets_with_convention_builder()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational()
                .Sequence("Snook", "Tasty")
                .IncrementBy(11)
                .Start(1729)
                .Min(111)
                .Max(2222)
                .Type<int>();

            var sequence = modelBuilder.Model.Relational().TryGetSequence("Snook", "Tasty");

            ValidateSchemaNamedSpecificSequence(sequence);
        }

        [Fact]
        public void Can_create_schema_named_sequence_with_specific_facets_with_convention_builder_using_nested_closure()
        {
            var modelBuilder = CreateConventionModelBuilder();

            modelBuilder
                .ForRelational(b =>
                    {
                        b.Sequence("Snook", "Tasty")
                            .IncrementBy(11)
                            .Start(1729)
                            .Min(111)
                            .Max(2222)
                            .Type<int>();
                    });

            var sequence = modelBuilder.Model.Relational().TryGetSequence("Snook", "Tasty");

            ValidateSchemaNamedSpecificSequence(sequence);
        }

        [Fact]
        public void ForRelational_methods_dont_break_out_of_the_generics()
        {
            var modelBuilder = CreateConventionModelBuilder();

            AssertIsGeneric(
                modelBuilder
                    .Entity<Customer>()
                    .ForRelational(b => { }));

            AssertIsGeneric(
                modelBuilder
                    .Entity<Customer>()
                    .Property(e => e.Name)
                    .ForRelational(b => { }));

            AssertIsGeneric(
                modelBuilder
                    .Entity<Customer>().Collection(e => e.Orders)
                    .InverseReference(e => e.Customer)
                    .ForRelational(b => { }));

            AssertIsGeneric(
                modelBuilder
                    .Entity<Order>()
                    .Reference(e => e.Customer)
                    .InverseCollection(e => e.Orders)
                    .ForRelational(b => { }));

            AssertIsGeneric(
                modelBuilder
                    .Entity<Order>()
                    .Reference(e => e.Details)
                    .InverseReference(e => e.Order)
                    .ForRelational(b => { }));
        }

        private void AssertIsGeneric(EntityTypeBuilder<Customer> _)
        {
        }

        private void AssertIsGeneric(PropertyBuilder<string> _)
        {
        }

        private void AssertIsGeneric(ReferenceCollectionBuilder<Customer, Order> _)
        {
        }

        private void AssertIsGeneric(CollectionReferenceBuilder<Order, Customer> _)
        {
        }

        private void AssertIsGeneric(ReferenceReferenceBuilder<Order, OrderDetails> _)
        {
        }

        protected virtual ModelBuilder CreateConventionModelBuilder()
        {
            return RelationalTestHelpers.Instance.CreateConventionBuilder();
        }

        protected virtual BasicModelBuilder CreateNonConventionModelBuilder()
        {
            return new BasicModelBuilder();
        }

        private static void ValidateSchemaNamedSpecificSequence(Sequence sequence)
        {
            Assert.Equal("Snook", sequence.Name);
            Assert.Equal("Tasty", sequence.Schema);
            Assert.Equal(11, sequence.IncrementBy);
            Assert.Equal(1729, sequence.StartValue);
            Assert.Equal(111, sequence.MinValue);
            Assert.Equal(2222, sequence.MaxValue);
            Assert.Same(typeof(int), sequence.Type);
        }

        private class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public IEnumerable<Order> Orders { get; set; }
        }

        private class Order
        {
            public int OrderId { get; set; }

            public int CustomerId { get; set; }
            public Customer Customer { get; set; }

            public OrderDetails Details { get; set; }
        }

        private class OrderDetails
        {
            public int Id { get; set; }

            public int OrderId { get; set; }
            public Order Order { get; set; }
        }
    }
}
