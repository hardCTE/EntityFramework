// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Microsoft.Data.Entity.Metadata.Compiled
{
    public abstract class CompiledEntityType<TEntity> : CompiledMetadataBase
        where TEntity : class
    {
        private IKey _key;
        private IProperty[] _properties;
        private IForeignKey[] _foreignKeys;
        private INavigation[] _navigations;
        private IIndex[] _indexes;

        protected CompiledEntityType(IModel model)
        {
            Model = model;
        }

        public IProperty FindProperty(string name) => GetProperties().FirstOrDefault(p => p.Name == name);

        public IProperty GetProperty(string name)
        {
            var property = FindProperty(name);
            if (property == null)
            {
                throw new Exception(string.Format("The property '{0}' on entity type '{1}' could not be found. Ensure that the property exists and has been included in the model.", name, typeof(TEntity).Name));
            }
            return property;
        }

        public INavigation FindNavigation(string name) => GetNavigations().FirstOrDefault(p => p.Name == name);

        public INavigation GetNavigation(string name)
        {
            var navigation = FindNavigation(name);
            if (navigation == null)
            {
                throw new Exception(string.Format("The navigation property '{0}' on entity type '{1}' could not be found. Ensure that the navigation property exists and has been included in the model.", name, typeof(TEntity).Name));
            }
            return navigation;
        }

        public Type ClrType => typeof(TEntity);

        public bool IsAbstract => false;

        public bool HasDerivedTypes => false;

        public IEntityType BaseType => null;
        
        public string DisplayName() => typeof(TEntity).Name;

        protected abstract IKey LoadKey();

        protected abstract IProperty[] LoadProperties();

        protected virtual IForeignKey[] LoadForeignKeys() => Empty.ForeignKeys;

        protected virtual INavigation[] LoadNavigations() => Empty.Navigations;

        protected virtual IIndex[] LoadIndexes() => Empty.Indexes;

        public IKey TryGetPrimaryKey()
        {
            if (_key == null)
            {
                Interlocked.CompareExchange(ref _key, LoadKey(), null);
            }

            return _key;
        }

        public IKey GetPrimaryKey() => LazyInitializer.EnsureInitialized(ref _key, LoadKey);

        public IEnumerable<IKey> GetKeys() => new[] { GetPrimaryKey() };

        public IEnumerable<IForeignKey> GetForeignKeys() 
            => LazyInitializer.EnsureInitialized(ref _foreignKeys, LoadForeignKeys);

        public IEnumerable<INavigation> GetNavigations() 
            => LazyInitializer.EnsureInitialized(ref _navigations, LoadNavigations);

        public IEnumerable<IIndex> GetIndexes() => LazyInitializer.EnsureInitialized(ref _indexes, LoadIndexes);

        public IEnumerable<IProperty> GetProperties() => EnsurePropertiesInitialized();

        public IEnumerable<IEntityType> GetDerivedTypes()
        {
            return Enumerable.Empty<IEntityType>();
        }

        public IEnumerable<IEntityType> GetConcreteTypesInHierarchy()
        {
            return Enumerable.Empty<IEntityType>();
        }

        private IProperty[] EnsurePropertiesInitialized() 
            => LazyInitializer.EnsureInitialized(ref _properties, LoadProperties);

        public bool UseEagerSnapshots => false;

        public IModel Model { get; }
    }
}
