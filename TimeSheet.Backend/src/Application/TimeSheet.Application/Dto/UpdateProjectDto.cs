﻿using System;

namespace TimeSheet.Application.Dto
{
    public class UpdateProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
