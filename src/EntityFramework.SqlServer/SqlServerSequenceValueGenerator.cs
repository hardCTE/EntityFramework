// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Globalization;
using JetBrains.Annotations;
using Microsoft.Data.Entity.Relational;
using Microsoft.Data.Entity.Utilities;
using Microsoft.Data.Entity.ValueGeneration;

namespace Microsoft.Data.Entity.SqlServer
{
    public class SqlServerSequenceValueGenerator<TValue> : HiLoValueGenerator<TValue>
    {
        private readonly SqlStatementExecutor _executor;
        private readonly ISqlServerSqlGenerator _sqlGenerator;
        private readonly ISqlServerConnection _connection;
        private readonly string _sequenceName;

        public SqlServerSequenceValueGenerator(
            [NotNull] SqlStatementExecutor executor,
            [NotNull] ISqlServerSqlGenerator generator,
            [NotNull] SqlServerSequenceValueGeneratorState generatorState,
            [NotNull] ISqlServerConnection connection)
            : base(Check.NotNull(generatorState, nameof(generatorState)))
        {
            Check.NotNull(executor, nameof(executor));
            Check.NotNull(generator, nameof(generator));
            Check.NotNull(connection, nameof(connection));

            _sequenceName = generatorState.SequenceName;
            _executor = executor;
            _sqlGenerator = generator;
            _connection = connection;
        }

        protected override long GetNewLowValue()
        {
            var sql = "SELECT NEXT VALUE FOR " + _sqlGenerator.DelimitIdentifier(_sequenceName);
            var nextValue = _executor.ExecuteScalar(_connection, _connection.DbTransaction, sql);

            return (long)Convert.ChangeType(nextValue, typeof(long), CultureInfo.InvariantCulture);
        }

        public override bool GeneratesTemporaryValues => false;
    }
}
