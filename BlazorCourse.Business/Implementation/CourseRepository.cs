using AutoMapper;
using BlazorCourse.Business.Contracts;
using BlazorCourse.Common;
using BlazorCourse.DataAccess.Data;
using BlazorCourse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCourse.Business.Implementation
{
    public class CourseRepository : ICourseRepository
    {
        private readonly BlazorCourseContext _context;
        private readonly IMapper _mapper;
        public CourseRepository(BlazorCourseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Result<CourseDto>> CreateCourse(CourseDto courseDto)
        {
            var course = _mapper.Map<CourseDto, Course>(courseDto);
            course.CreatedBy = "Blazor";
            var addedCourse =  await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            var returnData = _mapper.Map<Course, CourseDto>(addedCourse.Entity);
            return new Result<CourseDto>(true, ResultConstant.RecordCreateSuccessfully, returnData);
        }

        public async Task<Result<int>> DeleteCourse(int courseId)
        {
            var courseDetails = await _context.Courses.FindAsync(courseId);
            if (courseDetails != null)
            {
                _context.Courses.Remove(courseDetails);
                var result = await _context.SaveChangesAsync();
                return new Result<int>(true, ResultConstant.RecordRemoveSuccessfully, result);
            }
            return new Result<int>(false, ResultConstant.RecordRemoveNotSuccessfully);
        }

        public async Task<Result<IEnumerable<CourseDto>>> GetAllCourse()
        {
            try
            {
                var courseDtos = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(_context.Courses);
                return new Result<IEnumerable<CourseDto>>(true, ResultConstant.RecordFound, courseDtos, courseDtos.ToList().Count);
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<CourseDto>>(false, ResultConstant.RecordNotFound);
            }
        }

        public async Task<Result<CourseDto>> GetCourse(int courseId)
        {
            try
            {
                var data = await _context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
                var returnData = _mapper.Map<Course, CourseDto>(data);
                return new Result<CourseDto>(true, ResultConstant.RecordFound, returnData);
            }
            catch (Exception)
            {
                return new Result<CourseDto>(false, ResultConstant.RecordNotFound);
            }
        }

        public async Task<Result<CourseDto>> UpdateCourse(int courseId, CourseDto courseDto)
        {
            try
            {
                if (courseId == courseDto.Id)
                {
                    var courseDetails = await _context.Courses.FindAsync(courseId);
                    var course = _mapper.Map<CourseDto, Course>(courseDto, courseDetails);
                    course.UpdatedBy = "Blazor";
                    course.UpdatedDate = DateTime.Now;
                    var updateCourse = _context.Courses.Update(course);
                    await _context.SaveChangesAsync();
                    var returnData = _mapper.Map<Course, CourseDto>(updateCourse.Entity);
                    return new Result<CourseDto>(true, ResultConstant.RecordUpdateSuccessfully, returnData);
                }
                else
                    return new Result<CourseDto>(false, ResultConstant.RecordUpdateNotSuccessfully);
            }
            catch (Exception)
            {
                return new Result<CourseDto>(false, ResultConstant.RecordUpdateNotSuccessfully);
            }
        }

        public async Task<Result<CourseDto>> UpdateCourseImage(int courseId, string imagePath)
        {
            try
            {
                if (courseId > 0)
                {
                    var courseDetails = await _context.Courses.FindAsync(courseId);

                    courseDetails.UpdatedBy = "Blazor";
                    courseDetails.UpdatedDate = DateTime.Now;
                    courseDetails.ImageUrl = imagePath;
                    var updateCourse = _context.Courses.Update(courseDetails);
                    await _context.SaveChangesAsync();
                    var returnData = _mapper.Map<Course, CourseDto>(updateCourse.Entity);
                    return new Result<CourseDto>(true, ResultConstant.RecordUpdateSuccessfully, returnData);
                }
                else
                    return new Result<CourseDto>(false, ResultConstant.RecordUpdateNotSuccessfully);
            }
            catch (Exception)
            {
                return new Result<CourseDto>(false, ResultConstant.RecordUpdateNotSuccessfully);
            }
        }
    }
}
