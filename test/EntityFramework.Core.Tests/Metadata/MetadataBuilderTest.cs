// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Xunit;

namespace Microsoft.Data.Entity.Tests.Metadata
{
    public class MetadataBuilderTest
    {
        [Fact]
        public void Can_write_basic_model_builder_extension()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .ModelBuilderExtension("V1")
                .ModelBuilderExtension("V2");

            Assert.IsType<BasicModelBuilder>(returnedBuilder);

            var model = builder.Model;

            Assert.Equal("V2.Annotation", model["Annotation"]);
            Assert.Equal("V2.Metadata", model["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_model_builder_extension()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .ModelBuilderExtension("V1")
                .ModelBuilderExtension("V2");

            Assert.IsType<ModelBuilder>(returnedBuilder);

            var model = builder.Model;

            Assert.Equal("V2.Annotation", model["Annotation"]);
            Assert.Equal("V2.Metadata", model["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_entity_builder_extension()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity(typeof(Gunter))
                .EntityBuilderExtension("V1")
                .EntityBuilderExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_entity_builder_extension()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity(typeof(Gunter))
                .EntityBuilderExtension("V1")
                .EntityBuilderExtension("V2");

            Assert.IsType<EntityTypeBuilder>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_entity_builder_extension_and_use_with_generic_builder()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .EntityBuilderExtension("V1")
                .EntityBuilderExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder<Gunter>>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_entity_builder_extension_and_use_with_generic_builder()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .EntityBuilderExtension("V1")
                .EntityBuilderExtension("V2");

            Assert.IsType<EntityTypeBuilder<Gunter>>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_generic_basic_entity_builder_extension()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .GenericEntityBuilderExtension("V1")
                .GenericEntityBuilderExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder<Gunter>>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_generic_convention_entity_builder_extension()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .GenericEntityBuilderExtension("V1")
                .GenericEntityBuilderExtension("V2");

            Assert.IsType<EntityTypeBuilder<Gunter>>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_key_builder_extension()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Key(e => e.Id)
                .KeyBuilderExtension("V1")
                .KeyBuilderExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder.KeyBuilder>(returnedBuilder);

            var model = builder.Model;
            var key = model.GetEntityType(typeof(Gunter)).GetPrimaryKey();

            Assert.Equal("V2.Annotation", key["Annotation"]);
            Assert.Equal("V2.Metadata", key["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_key_builder_extension()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Key(e => e.Id)
                .KeyBuilderExtension("V1")
                .KeyBuilderExtension("V2");

            Assert.IsType<KeyBuilder>(returnedBuilder);

            var model = builder.Model;
            var key = model.GetEntityType(typeof(Gunter)).GetPrimaryKey();

            Assert.Equal("V2.Annotation", key["Annotation"]);
            Assert.Equal("V2.Metadata", key["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_property_builder_extension()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Property(e => e.Id)
                .PropertyBuilderExtension("V1")
                .PropertyBuilderExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder.PropertyBuilder>(returnedBuilder);

            var model = builder.Model;
            var property = model.GetEntityType(typeof(Gunter)).GetProperty("Id");

            Assert.Equal("V2.Annotation", property["Annotation"]);
            Assert.Equal("V2.Metadata", property["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_property_builder_extension()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Property(e => e.Id)
                .PropertyBuilderExtension("V1")
                .PropertyBuilderExtension("V2");

            Assert.IsType<PropertyBuilder>(returnedBuilder);

            var model = builder.Model;
            var property = model.GetEntityType(typeof(Gunter)).GetProperty("Id");

            Assert.Equal("V2.Annotation", property["Annotation"]);
            Assert.Equal("V2.Metadata", property["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_foreign_key_builder_extension()
        {
            var builder = new BasicModelBuilder();

            builder.Entity<Gunter>().Key(e => e.Id);

            var returnedBuilder = builder
                .Entity<Gate>()
                .ForeignKey<Gunter>(e => e.GunterId)
                .ForeignKeyBuilderExtension("V1")
                .ForeignKeyBuilderExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder.ForeignKeyBuilder>(returnedBuilder);

            var model = builder.Model;
            var foreignKey = model.GetEntityType(typeof(Gate)).ForeignKeys.Single();

            Assert.Equal("V2.Annotation", foreignKey["Annotation"]);
            Assert.Equal("V2.Metadata", foreignKey["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_index_builder_extension()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Index(e => e.Id)
                .IndexBuilderExtension("V1")
                .IndexBuilderExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder.IndexBuilder>(returnedBuilder);

            var model = builder.Model;
            var index = model.GetEntityType(typeof(Gunter)).Indexes.Single();

            Assert.Equal("V2.Annotation", index["Annotation"]);
            Assert.Equal("V2.Metadata", index["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_index_builder_extension()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Index(e => e.Id)
                .IndexBuilderExtension("V1")
                .IndexBuilderExtension("V2");

            Assert.IsType<IndexBuilder>(returnedBuilder);

            var model = builder.Model;
            var index = model.GetEntityType(typeof(Gunter)).Indexes.Single();

            Assert.Equal("V2.Annotation", index["Annotation"]);
            Assert.Equal("V2.Metadata", index["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_one_to_many_builder_extension()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>().Collection(e => e.Gates).InverseReference(e => e.Gunter)
                .OneToManyBuilderExtension("V1")
                .OneToManyBuilderExtension("V2");

            Assert.IsType<ReferenceCollectionBuilder<Gunter, Gate>>(returnedBuilder);

            var model = builder.Model;
            var foreignKey = model.GetEntityType(typeof(Gate)).ForeignKeys.Single();

            Assert.Equal("V2.Annotation", foreignKey["Annotation"]);
            Assert.Equal("V2.Metadata", foreignKey["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_many_to_one_builder_extension()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gate>().Reference(e => e.Gunter).InverseCollection(e => e.Gates)
                .ManyToOneBuilderExtension("V1")
                .ManyToOneBuilderExtension("V2");

            Assert.IsType<CollectionReferenceBuilder<Gate, Gunter>>(returnedBuilder);

            var model = builder.Model;
            var foreignKey = model.GetEntityType(typeof(Gate)).ForeignKeys.Single();

            Assert.Equal("V2.Annotation", foreignKey["Annotation"]);
            Assert.Equal("V2.Metadata", foreignKey["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_one_to_one_builder_extension()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Avatar>().Reference(e => e.Gunter).InverseReference(e => e.Avatar)
                .PrincipalKey<Gunter>(e => e.Id)
                .OneToOneBuilderExtension("V1")
                .OneToOneBuilderExtension("V2");

            Assert.IsType<ReferenceReferenceBuilder>(returnedBuilder);

            var model = builder.Model;
            var foreignKey = model.GetEntityType(typeof(Avatar)).ForeignKeys.Single();

            Assert.Equal("V2.Annotation", foreignKey["Annotation"]);
            Assert.Equal("V2.Metadata", foreignKey["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_model_builder_extension_with_common_name()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<BasicModelBuilder>(returnedBuilder);

            var model = builder.Model;

            Assert.Equal("V2.Annotation", model["Annotation"]);
            Assert.Equal("V2.Metadata", model["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_model_builder_extension_with_common_name()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<ModelBuilder>(returnedBuilder);

            var model = builder.Model;

            Assert.Equal("V2.Annotation", model["Annotation"]);
            Assert.Equal("V2.Metadata", model["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_entity_builder_extension_with_common_name()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity(typeof(Gunter))
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_entity_builder_extension_with_common_name()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity(typeof(Gunter))
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<EntityTypeBuilder>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_entity_builder_extension_and_use_with_generic_builder_with_common_name()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder<Gunter>>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_entity_builder_extension_and_use_with_generic_builder_with_common_name()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<EntityTypeBuilder<Gunter>>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_generic_basic_entity_builder_extension_with_common_name()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder<Gunter>>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_generic_convention_entity_builder_extension_with_common_name()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<EntityTypeBuilder<Gunter>>(returnedBuilder);

            var model = builder.Model;
            var entityType = model.GetEntityType(typeof(Gunter));

            Assert.Equal("V2.Annotation", entityType["Annotation"]);
            Assert.Equal("V2.Metadata", entityType["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_key_builder_extension_with_common_name()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Key(e => e.Id)
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder.KeyBuilder>(returnedBuilder);

            var model = builder.Model;
            var key = model.GetEntityType(typeof(Gunter)).GetPrimaryKey();

            Assert.Equal("V2.Annotation", key["Annotation"]);
            Assert.Equal("V2.Metadata", key["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_key_builder_extension_with_common_name()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Key(e => e.Id)
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<KeyBuilder>(returnedBuilder);

            var model = builder.Model;
            var key = model.GetEntityType(typeof(Gunter)).GetPrimaryKey();

            Assert.Equal("V2.Annotation", key["Annotation"]);
            Assert.Equal("V2.Metadata", key["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_property_builder_extension_with_common_name()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Property(e => e.Id)
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder.PropertyBuilder>(returnedBuilder);

            var model = builder.Model;
            var property = model.GetEntityType(typeof(Gunter)).GetProperty("Id");

            Assert.Equal("V2.Annotation", property["Annotation"]);
            Assert.Equal("V2.Metadata", property["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_property_builder_extension_with_common_name()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Property(e => e.Id)
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<PropertyBuilder>(returnedBuilder);

            var model = builder.Model;
            var property = model.GetEntityType(typeof(Gunter)).GetProperty("Id");

            Assert.Equal("V2.Annotation", property["Annotation"]);
            Assert.Equal("V2.Metadata", property["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_foreign_key_builder_extension_with_common_name()
        {
            var builder = new BasicModelBuilder();

            builder.Entity<Gunter>().Key(e => e.Id);

            var returnedBuilder = builder
                .Entity<Gate>()
                .ForeignKey<Gunter>(e => e.GunterId)
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder.ForeignKeyBuilder>(returnedBuilder);

            var model = builder.Model;
            var foreignKey = model.GetEntityType(typeof(Gate)).ForeignKeys.Single();

            Assert.Equal("V2.Annotation", foreignKey["Annotation"]);
            Assert.Equal("V2.Metadata", foreignKey["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_basic_index_builder_extension_with_common_name()
        {
            var builder = new BasicModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Index(e => e.Id)
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<BasicModelBuilder.EntityTypeBuilder.IndexBuilder>(returnedBuilder);

            var model = builder.Model;
            var index = model.GetEntityType(typeof(Gunter)).Indexes.Single();

            Assert.Equal("V2.Annotation", index["Annotation"]);
            Assert.Equal("V2.Metadata", index["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_index_builder_extension_with_common_name()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>()
                .Index(e => e.Id)
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<IndexBuilder>(returnedBuilder);

            var model = builder.Model;
            var index = model.GetEntityType(typeof(Gunter)).Indexes.Single();

            Assert.Equal("V2.Annotation", index["Annotation"]);
            Assert.Equal("V2.Metadata", index["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_one_to_many_builder_extension_with_common_name()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gunter>().Collection(e => e.Gates).InverseReference(e => e.Gunter)
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<ReferenceCollectionBuilder<Gunter, Gate>>(returnedBuilder);

            var model = builder.Model;
            var foreignKey = model.GetEntityType(typeof(Gate)).ForeignKeys.Single();

            Assert.Equal("V2.Annotation", foreignKey["Annotation"]);
            Assert.Equal("V2.Metadata", foreignKey["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_many_to_one_builder_extension_with_common_name()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Gate>().Reference(e => e.Gunter).InverseCollection(e => e.Gates)
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<CollectionReferenceBuilder<Gate, Gunter>>(returnedBuilder);

            var model = builder.Model;
            var foreignKey = model.GetEntityType(typeof(Gate)).ForeignKeys.Single();

            Assert.Equal("V2.Annotation", foreignKey["Annotation"]);
            Assert.Equal("V2.Metadata", foreignKey["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        [Fact]
        public void Can_write_convention_one_to_one_builder_extension_with_common_name()
        {
            var builder = CreateModelBuilder();

            var returnedBuilder = builder
                .Entity<Avatar>().Reference(e => e.Gunter).InverseReference(e => e.Avatar)
                .PrincipalKey<Gunter>(e => e.Id)
                .SharedNameExtension("V1")
                .SharedNameExtension("V2");

            Assert.IsType<ReferenceReferenceBuilder>(returnedBuilder);

            var model = builder.Model;
            var foreignKey = model.GetEntityType(typeof(Avatar)).ForeignKeys.Single();

            Assert.Equal("V2.Annotation", foreignKey["Annotation"]);
            Assert.Equal("V2.Metadata", foreignKey["Metadata"]);
            Assert.Equal("V2.Model", model["Model"]);
        }

        protected virtual ModelBuilder CreateModelBuilder()
        {
            return TestHelpers.Instance.CreateConventionBuilder();
        }

        private class Gunter
        {
            public int Id { get; set; }

            public ICollection<Gate> Gates { get; set; }

            public Avatar Avatar { get; set; }
        }

        private class Gate
        {
            public int Id { get; set; }

            public int GunterId { get; set; }
            public Gunter Gunter { get; set; }
        }

        private class Avatar
        {
            public int Id { get; set; }

            public Gunter Gunter { get; set; }
        }
    }

    internal static class TestExtensions
    {
        public static TBuilder ModelBuilderExtension<TBuilder>(this TBuilder builder, string value)
            where TBuilder : IModelBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return builder;
        }

        public static TBuilder EntityBuilderExtension<TBuilder>(this TBuilder builder, string value)
            where TBuilder : IEntityTypeBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return builder;
        }

        public static TBuilder GenericEntityBuilderExtension<TEntity, TBuilder>(this IEntityTypeBuilder<TEntity, TBuilder> typeBuilder, string value)
            where TEntity : class
            where TBuilder : IEntityTypeBuilder<TEntity, TBuilder>
        {
            typeBuilder.Annotation("Annotation", value + ".Annotation");
            typeBuilder.Metadata["Metadata"] = value + ".Metadata";
            typeBuilder.Model["Model"] = value + ".Model";

            return (TBuilder)typeBuilder;
        }

        public static TBuilder KeyBuilderExtension<TBuilder>(this TBuilder builder, string value)
            where TBuilder : IKeyBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return builder;
        }

        public static TBuilder PropertyBuilderExtension<TBuilder>(this TBuilder builder, string value)
            where TBuilder : IPropertyBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return builder;
        }

        public static TBuilder ForeignKeyBuilderExtension<TBuilder>(this TBuilder builder, string value)
            where TBuilder : IForeignKeyBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return builder;
        }

        public static TBuilder IndexBuilderExtension<TBuilder>(this TBuilder builder, string value)
            where TBuilder : IIndexBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return builder;
        }

        public static TBuilder OneToManyBuilderExtension<TBuilder>(this IReferenceCollectionBuilder<TBuilder> builder, string value)
            where TBuilder : IReferenceCollectionBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return (TBuilder)builder;
        }

        public static TBuilder ManyToOneBuilderExtension<TBuilder>(this ICollectionReferenceBuilder<TBuilder> builder, string value)
            where TBuilder : ICollectionReferenceBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return (TBuilder)builder;
        }

        public static TBuilder OneToOneBuilderExtension<TBuilder>(this IReferenceReferenceBuilder<TBuilder> builder, string value)
            where TBuilder : IReferenceReferenceBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return (TBuilder)builder;
        }

        public static TBuilder SharedNameExtension<TBuilder>(this IModelBuilder<TBuilder> builder, string value)
            where TBuilder : IModelBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return (TBuilder)builder;
        }

        public static TBuilder SharedNameExtension<TBuilder>(this IEntityTypeBuilder<TBuilder> typeBuilder, string value)
            where TBuilder : IEntityTypeBuilder<TBuilder>
        {
            typeBuilder.Annotation("Annotation", value + ".Annotation");
            typeBuilder.Metadata["Metadata"] = value + ".Metadata";
            typeBuilder.Model["Model"] = value + ".Model";

            return (TBuilder)typeBuilder;
        }

        public static TBuilder SharedNameExtension<TEntity, TBuilder>(this IEntityTypeBuilder<TEntity, TBuilder> typeBuilder, string value)
            where TEntity : class
            where TBuilder : IEntityTypeBuilder<TEntity, TBuilder>
        {
            typeBuilder.Annotation("Annotation", value + ".Annotation");
            typeBuilder.Metadata["Metadata"] = value + ".Metadata";
            typeBuilder.Model["Model"] = value + ".Model";

            return (TBuilder)typeBuilder;
        }

        public static TBuilder SharedNameExtension<TBuilder>(this IKeyBuilder<TBuilder> builder, string value)
            where TBuilder : IKeyBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return (TBuilder)builder;
        }

        public static TBuilder SharedNameExtension<TBuilder>(this IPropertyBuilder<TBuilder> builder, string value)
            where TBuilder : IPropertyBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return (TBuilder)builder;
        }

        public static TBuilder SharedNameExtension<TBuilder>(this IForeignKeyBuilder<TBuilder> builder, string value)
            where TBuilder : IForeignKeyBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return (TBuilder)builder;
        }

        public static TBuilder SharedNameExtension<TBuilder>(this IIndexBuilder<TBuilder> builder, string value)
            where TBuilder : IIndexBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return (TBuilder)builder;
        }

        public static TBuilder SharedNameExtension<TBuilder>(this IReferenceCollectionBuilder<TBuilder> builder, string value)
            where TBuilder : IReferenceCollectionBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return (TBuilder)builder;
        }

        public static TBuilder SharedNameExtension<TBuilder>(this ICollectionReferenceBuilder<TBuilder> builder, string value)
            where TBuilder : ICollectionReferenceBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return (TBuilder)builder;
        }

        public static TBuilder SharedNameExtension<TBuilder>(this IReferenceReferenceBuilder<TBuilder> builder, string value)
            where TBuilder : IReferenceReferenceBuilder<TBuilder>
        {
            builder.Annotation("Annotation", value + ".Annotation");
            builder.Metadata["Metadata"] = value + ".Metadata";
            builder.Model["Model"] = value + ".Model";

            return (TBuilder)builder;
        }
    }
}
