﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Core.Infra.UoW
{
    public class UnitOfWork
    {
        public DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
