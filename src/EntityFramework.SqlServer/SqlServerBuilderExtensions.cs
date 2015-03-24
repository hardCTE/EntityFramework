// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using JetBrains.Annotations;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.SqlServer.Metadata;
using Microsoft.Data.Entity.Utilities;

// ReSharper disable once CheckNamespace

namespace Microsoft.Data.Entity
{
    public static class SqlServerBuilderExtensions
    {
        public static SqlServerPropertyBuilder ForSqlServer(
            [NotNull] this PropertyBuilder propertyBuilder)
        {
            Check.NotNull(propertyBuilder, nameof(propertyBuilder));

            return new SqlServerPropertyBuilder(propertyBuilder.Metadata);
        }

        public static PropertyBuilder ForSqlServer(
            [NotNull] this PropertyBuilder propertyBuilder,
            [NotNull] Action<SqlServerPropertyBuilder> builderAction)
        {
            Check.NotNull(propertyBuilder, nameof(propertyBuilder));
            Check.NotNull(builderAction, nameof(builderAction));

            builderAction(ForSqlServer(propertyBuilder));

            return propertyBuilder;
        }

        public static PropertyBuilder<TProperty> ForSqlServer<TProperty>(
            [NotNull] this PropertyBuilder<TProperty> propertyBuilder,
            [NotNull] Action<SqlServerPropertyBuilder> builderAction)
        {
            Check.NotNull(propertyBuilder, nameof(propertyBuilder));
            Check.NotNull(builderAction, nameof(builderAction));

            builderAction(ForSqlServer(propertyBuilder));

            return propertyBuilder;
        }

        public static SqlServerEntityTypeBuilder ForSqlServer(
            [NotNull] this EntityTypeBuilder entityTypeBuilder)
        {
            Check.NotNull(entityTypeBuilder, nameof(entityTypeBuilder));

            return new SqlServerEntityTypeBuilder(entityTypeBuilder.Metadata);
        }

        public static EntityTypeBuilder ForSqlServer(
            [NotNull] this EntityTypeBuilder entityTypeBuilder,
            [NotNull] Action<SqlServerEntityTypeBuilder> builderAction)
        {
            Check.NotNull(entityTypeBuilder, nameof(entityTypeBuilder));

            builderAction(ForSqlServer(entityTypeBuilder));

            return entityTypeBuilder;
        }

        public static EntityTypeBuilder<TEntity> ForSqlServer<TEntity>(
            [NotNull] this EntityTypeBuilder<TEntity> entityTypeBuilder,
            [NotNull] Action<SqlServerEntityTypeBuilder> builderAction)
            where TEntity : class
        {
            Check.NotNull(entityTypeBuilder, nameof(entityTypeBuilder));

            builderAction(ForSqlServer(entityTypeBuilder));

            return entityTypeBuilder;
        }

        public static SqlServerKeyBuilder ForSqlServer(
            [NotNull] this KeyBuilder keyBuilder)
        {
            Check.NotNull(keyBuilder, nameof(keyBuilder));

            return new SqlServerKeyBuilder(keyBuilder.Metadata);
        }

        public static KeyBuilder ForSqlServer(
            [NotNull] this KeyBuilder keyBuilder,
            [NotNull] Action<SqlServerKeyBuilder> builderAction)
        {
            Check.NotNull(keyBuilder, nameof(keyBuilder));
            Check.NotNull(builderAction, nameof(builderAction));

            builderAction(ForSqlServer(keyBuilder));

            return keyBuilder;
        }

        public static SqlServerIndexBuilder ForSqlServer(
            [NotNull] this IndexBuilder indexBuilder)
        {
            Check.NotNull(indexBuilder, nameof(indexBuilder));

            return new SqlServerIndexBuilder(indexBuilder.Metadata);
        }

        public static IndexBuilder ForSqlServer(
            [NotNull] this IndexBuilder indexBuilder,
            [NotNull] Action<SqlServerIndexBuilder> builderAction)
        {
            Check.NotNull(indexBuilder, nameof(indexBuilder));
            Check.NotNull(builderAction, nameof(builderAction));

            builderAction(ForSqlServer(indexBuilder));

            return indexBuilder;
        }

        public static SqlServerForeignKeyBuilder ForSqlServer(
            [NotNull] this ReferenceCollectionBuilder referenceCollectionBuilder)
        {
            Check.NotNull(referenceCollectionBuilder, nameof(referenceCollectionBuilder));

            return new SqlServerForeignKeyBuilder(referenceCollectionBuilder.Metadata);
        }

        public static ReferenceCollectionBuilder ForSqlServer(
            [NotNull] this ReferenceCollectionBuilder referenceCollectionBuilder,
            [NotNull] Action<SqlServerForeignKeyBuilder> builderAction)
        {
            Check.NotNull(referenceCollectionBuilder, nameof(referenceCollectionBuilder));
            Check.NotNull(builderAction, nameof(builderAction));

            builderAction(ForSqlServer(referenceCollectionBuilder));

            return referenceCollectionBuilder;
        }

        public static ReferenceCollectionBuilder<TEntity, TRelatedEntity> ForSqlServer<TEntity, TRelatedEntity>(
            [NotNull] this ReferenceCollectionBuilder<TEntity, TRelatedEntity> referenceCollectionBuilder,
            [NotNull] Action<SqlServerForeignKeyBuilder> builderAction)
            where TEntity : class
        {
            Check.NotNull(referenceCollectionBuilder, nameof(referenceCollectionBuilder));
            Check.NotNull(builderAction, nameof(builderAction));

            builderAction(ForSqlServer(referenceCollectionBuilder));

            return referenceCollectionBuilder;
        }

        public static SqlServerForeignKeyBuilder ForSqlServer(
            [NotNull] this CollectionReferenceBuilder collectionReferenceBuilder)
        {
            Check.NotNull(collectionReferenceBuilder, nameof(collectionReferenceBuilder));

            return new SqlServerForeignKeyBuilder(collectionReferenceBuilder.Metadata);
        }

        public static CollectionReferenceBuilder ForSqlServer(
            [NotNull] this CollectionReferenceBuilder collectionReferenceBuilder,
            [NotNull] Action<SqlServerForeignKeyBuilder> builderAction)
        {
            Check.NotNull(collectionReferenceBuilder, nameof(collectionReferenceBuilder));
            Check.NotNull(builderAction, nameof(builderAction));

            builderAction(ForSqlServer(collectionReferenceBuilder));

            return collectionReferenceBuilder;
        }

        public static CollectionReferenceBuilder<TEntity, TRelatedEntity> ForSqlServer<TEntity, TRelatedEntity>(
            [NotNull] this CollectionReferenceBuilder<TEntity, TRelatedEntity> collectionReferenceBuilder,
            [NotNull] Action<SqlServerForeignKeyBuilder> builderAction)
            where TEntity : class
        {
            Check.NotNull(collectionReferenceBuilder, nameof(collectionReferenceBuilder));
            Check.NotNull(builderAction, nameof(builderAction));

            builderAction(ForSqlServer(collectionReferenceBuilder));

            return collectionReferenceBuilder;
        }

        public static SqlServerForeignKeyBuilder ForSqlServer(
            [NotNull] this ReferenceReferenceBuilder referenceReferenceBuilder)
        {
            Check.NotNull(referenceReferenceBuilder, nameof(referenceReferenceBuilder));

            return new SqlServerForeignKeyBuilder(referenceReferenceBuilder.Metadata);
        }

        public static ReferenceReferenceBuilder ForSqlServer(
            [NotNull] this ReferenceReferenceBuilder referenceReferenceBuilder,
            [NotNull] Action<SqlServerForeignKeyBuilder> builderAction)
        {
            Check.NotNull(referenceReferenceBuilder, nameof(referenceReferenceBuilder));
            Check.NotNull(builderAction, nameof(builderAction));

            builderAction(ForSqlServer(referenceReferenceBuilder));

            return referenceReferenceBuilder;
        }

        public static ReferenceReferenceBuilder<TEntity, TRelatedEntity> ForSqlServer<TEntity, TRelatedEntity>(
            [NotNull] this ReferenceReferenceBuilder<TEntity, TRelatedEntity> referenceReferenceBuilder,
            [NotNull] Action<SqlServerForeignKeyBuilder> builderAction)
        {
            Check.NotNull(referenceReferenceBuilder, nameof(referenceReferenceBuilder));
            Check.NotNull(builderAction, nameof(builderAction));

            builderAction(ForSqlServer(referenceReferenceBuilder));

            return referenceReferenceBuilder;
        }

        public static SqlServerModelBuilder ForSqlServer(
            [NotNull] this ModelBuilder modelBuilder)
        {
            Check.NotNull(modelBuilder, nameof(modelBuilder));

            return new SqlServerModelBuilder(modelBuilder.Model);
        }

        public static ModelBuilder ForSqlServer(
            [NotNull] this ModelBuilder modelBuilder,
            [NotNull] Action<SqlServerModelBuilder> builderAction)
        {
            Check.NotNull(modelBuilder, nameof(modelBuilder));
            Check.NotNull(builderAction, nameof(builderAction));

            builderAction(ForSqlServer(modelBuilder));

            return modelBuilder;
        }
    }
}
