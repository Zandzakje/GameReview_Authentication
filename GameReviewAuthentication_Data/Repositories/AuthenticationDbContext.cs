﻿using System;
using System.Collections.Generic;
using System.Text;
using GameReviewAuthentication_Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GameReviewAuthentication_Data.Repositories
{
    public class AuthenticationDbContext : DbContext
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> opt) : base(opt)
        {

        }

        public DbSet<LoginDto> Users { get; set; }
    }
}
