using System;
using System.ComponentModel.DataAnnotations;

namespace SATProject.MVC.DATA.EF//.OTMetaData
{

        public class CourseMetadata
        {

            //public int CourseID { get; set; }

            [Required(ErrorMessage = "*")]
            [StringLength(50, ErrorMessage = "*cannot exceed past 50 characters")]
            [Display(Name = "Course")]
            public string CourseName { get; set; }

            [Required(ErrorMessage = "*")]
            [UIHint("MultilineText")]
            [Display(Name = "Description")]
            public string CourseDescription { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Credit Hours")]
            public byte CreditHours { get; set; }

            [UIHint("MultilineText")]
            [StringLength(250, ErrorMessage = "*cannot exceed past 250 characters")]
            [DisplayFormat(NullDisplayText = "N/A")]
            public string Curriculum { get; set; }

            [UIHint("MultilineText")]
            [StringLength(500, ErrorMessage = "*cannot exceed 500 characters")]
            [DisplayFormat(NullDisplayText = "N/A")]
            public string Notes { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Is Active")]
            public bool IsActive { get; set; }
        }

        [MetadataType(typeof(CourseMetadata))]
        public partial class Course { }

        public class EnrollmentMetadata
        {
            //public int EnrollmentID { get; set; }

            [Required(ErrorMessage = "*")]
            public int StudentID { get; set; }

            [Required(ErrorMessage = "*")]
            public int ScheduledClassesID { get; set; }

            [Required(ErrorMessage = "*needs to be formatted in the right date format")]
            [Display(Name = "Enrollment Date")]
            [DisplayFormat(DataFormatString = "{0:d}, ApplyFormatEditMode = true")]
            public DateTime EnrollmentDate { get; set; }
        }

        [MetadataType(typeof(EnrollmentMetadata))]
        public partial class Enrollment { }

        public class ScheduledClassMetadata
        {
            //public int ScheduledClassesID { get; set; }

            [Required(ErrorMessage = "*")]
            public int CourseID { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Start Date")]
            [DisplayFormat(DataFormatString = "{0:d}, ApplyFormatEditMode = true")]
            public DateTime StartDate { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "End Date")]
            [DisplayFormat(DataFormatString = "{0:d}, ApplyFormatEditMode = true")]
            public DateTime EndDate { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Instructor Name")]
            [StringLength(50, ErrorMessage = "*cannot exceed 50 characters")]
            public string InstructorName { get; set; }

            [Required(ErrorMessage = "*")]
            [StringLength(20, ErrorMessage = "*cannot exceed 20 characters")]
            public string Location { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Class Status")]
            public int SCSID { get; set; }
        }
        [MetadataType(typeof(ScheduledClassMetadata))]
        public partial class ScheduledClass { }

        public class ScheduledClassStatusMetadata
        {
            //public int SCSID { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Status")]
            [StringLength(100, ErrorMessage = "*cannot exceed 100 characters")]
            public string SCSName { get; set; }
        }

        [MetadataType(typeof(ScheduledClassStatusMetadata))]
        public partial class ScheduledClassStatus { }

        public class StudentMetadata
        {
            //public int StudentID { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "First Name")]
            [StringLength(50, ErrorMessage = "*cannot exceed 50 characters")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Last Name")]
            [StringLength(50, ErrorMessage = "*cannot exceed 50 characters")]
            public string LastName { get; set; }

            [DisplayFormat(NullDisplayText = "N/A")]
            [StringLength(50, ErrorMessage = "*cannot exceed 50 characters")]
            public string Major { get; set; }

            [DisplayFormat(NullDisplayText = "N/A")]
            [StringLength(50, ErrorMessage = "*cannot exceed 50 characters")]
            public string Address { get; set; }

            [DisplayFormat(NullDisplayText = "N/A")]
            [StringLength(25, ErrorMessage = "*cannot exceed 25 characters")]
            public string City { get; set; }

            [DisplayFormat(NullDisplayText = "N/A")]
            [StringLength(2, ErrorMessage = "*cannot exceed 2 characters")]
            public string State { get; set; }

            [Display(Name = "Zip Code")]
            [DisplayFormat(NullDisplayText = "N/A")]
            [StringLength(10, ErrorMessage = "*cannot exceed 10 characters")]
            public string ZipCode { get; set; }

            [StringLength(13, ErrorMessage = "*cannot exceed 13 characters")]
            [DisplayFormat(NullDisplayText = "N/A")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "*")]
            [StringLength(60, ErrorMessage = "*cannot exceed 60 characters")]
            public string Email { get; set; }

            [Display(Name = "Image")]
            [DisplayFormat(NullDisplayText = "N/A")]
            [StringLength(100, ErrorMessage = "*cannot exceed 100 characters")]
            public string PhotoURL { get; set; }

            [Required(ErrorMessage = "*")]
            public int SSID { get; set; }

        }
        [MetadataType(typeof(StudentMetadata))]
        public partial class Student
        {
            //[Display(Name = "Student Full Name")]
            //public string FullName
            //{
            //    get
            //    {
            //        return FirstName + " " + LastName;
            //    }
            //}
            [Display(Name = "Student Full Name")]
            public string FullName { get  { return FirstName + " " + LastName; } }
        }

        public class StudentStatusMetadata
        {
            //public int SSID { get; set; }

            [Required(ErrorMessage = "*")]
            [Display(Name = "Status")]
            [StringLength(30, ErrorMessage = "*cannot exceed 30 characters")]
            public string SSName { get; set; }

            [Display(Name = "Description")]
            [DisplayFormat(NullDisplayText = "N/A")]
            [StringLength(250, ErrorMessage = "*cannot exceed 250 characters")]
            [UIHint("MultilineText")]
            public string SSDescription { get; set; }
        }
        [MetadataType(typeof(StudentStatusMetadata))]
        public partial class StudentStatus
        {

        }
    }

