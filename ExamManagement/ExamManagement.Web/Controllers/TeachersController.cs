﻿using System.Net;
using System.Net.Http;
using ExamManagement.Core.Interfaces.Services;
using ExamManagement.Web.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ExamManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : Controller
    {
        private readonly IGradeService _gradeService;

        public TeachersController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        [HttpPut]
        public HttpResponseMessage UpdateGrade([FromBody] UpdateGradeRequest setGradeRequest)
        {
            _gradeService.SetGrade(setGradeRequest.GradeId, setGradeRequest.Grade);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public JsonResult GetGrade([FromQuery] GetGradeRequest getGradeRequest)
        {
            return Json(_gradeService.GetGradeByStudentId(getGradeRequest.StudentId, getGradeRequest.ExamId));
        }
    }
}