using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.General
{
    public class BaseModel
    {
        public BaseModel()
        {
        }

        public BaseModel(BaseEntity entity)
        {
            if (entity == null) return;

            Id = entity.Id;
            Note = entity.Note??"";
            CreatedDate = entity.CreatedDate.ToString("HH:mm dd/MM/yyyy");
            CreatedUserId = entity.CreatedUserId;
            UpdatedDate = entity.UpdatedDate?.ToString("HH:mm dd/MM/yyyy");
            UpdatedUserId = entity.UpdatedUserId;
        }

        public void CopyTo(BaseEntity entity)
        {
            entity.Note = Note;
        }

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        public string Note { get; set; }

        protected string UpdatedDate { get; set; }

        protected int? UpdatedUserId { get; set; }

        protected string CreatedDate { get; set; }

        protected int CreatedUserId { get; set; }
    }
}
