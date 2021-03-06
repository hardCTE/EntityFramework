// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Data.Entity.Metadata.Compiled
{
    public abstract class CompiledSimpleForeignKey : NoAnnotations
    {
        private readonly IModel _model;

        protected CompiledSimpleForeignKey(IModel model)
        {
            _model = model;
        }

        protected abstract ForeignKeyDefinition Definition { get; }

        public IReadOnlyList<IProperty> Properties => new[] { EntityType.GetProperties().ElementAt(Definition.DependentPropertyIndex) };

        public IKey PrincipalKey => PrincipalEntityType.GetPrimaryKey();

        public IEntityType PrincipalEntityType => _model.EntityTypes[Definition.PrincipalIndex];

        public IEntityType EntityType => _model.EntityTypes[Definition.DependentIndex];

        public bool IsRequired => Properties.Any(p => !p.IsNullable);

        public bool IsUnique => false;

        protected struct ForeignKeyDefinition
        {
            public short DependentIndex;
            public short DependentPropertyIndex;
            public short PrincipalIndex;

            public ForeignKeyDefinition(short dependentIndex, short dependentPropertyIndex, short principalIndex)
            {
                DependentIndex = dependentIndex;
                DependentPropertyIndex = dependentPropertyIndex;
                PrincipalIndex = principalIndex;
            }
        }
    }
}
