using System;
using System.ComponentModel.DataAnnotations;

namespace StaffingPlanner.Models
{
	public class ClientMetadata
	{
		[Key]
		[Required]
		[Display(Name = "Client ID")]
		public int clientId;

		[Required]
		[Display(Name = "Client Name")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Client name must be between 2 and 50 characters in length.")]
		public string clientName;

		[Display(Name = "Sub-Business")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Sub-Business cannot be more than 50 characters in length.")]
		public string subbusiness;

		[Display(Name = "Active")]
		public bool activeClient;

		[Required]
		[Display(Name = "Last Edited By")]
		public string lastEditedBy;

		[Required]
		[Display(Name = "Last Edited On")]
		public DateTime editDate;
	}

	public class ConsultantMetadata
	{
		[Key]
		[Required]
		[Display(Name = "Consultant ID")]
		public int consultantId;

		[Required]
		[Display(Name = "Consultant Name")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Client Name cannot be more than 50 characters in length.")]
		public string consultantName;

		[Display(Name = "Sogeti Start Date")]
		public Nullable<DateTime> sogetiStartDate;

		[Required]
		[Display(Name = "Active")]
		public bool activeEmployee;

		[Required]
		[Display(Name = "Last Edited By")]
		public string lastEditedBy;

		[Required]
		[Display(Name = "Last Edited On")]
		public DateTime editDate;
	}

	public class LostOpportunityMetadata
	{
		[Required]
		[Display(Name = "Project Id")]
		public int projectId;

		[Required]
		[Display(Name = "Lost Reason Id")]
		public int lostReasonId;

		[Required]
		[Display(Name = "Last Edited By")]
		public string lastEditedBy;

		[Required]
		[Display(Name = "Last Edited On")]
		public DateTime editDate;
	}

	public class LostReasonMetadata
	{
		[Key]
		[Required]
		[Display(Name = "Lost Reason Id")]
		public int lostReasonId { get; set; }

		[Required]
		[Display(Name = "Reason")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Reason cannot be more than 50 characters in length.")]
		public string reason { get; set; }
	}

	public class ProjectMetadata
	{
		[Key]
		[Required]
		[Display(Name ="Project Id")]
		public int projectId;

		[Required]
		[Display(Name ="Client Id")]
		public int clientId;

		[Required]
		[Display(Name ="Project Status Id")]
		public int projectStatusID;

		[Required]
		[Display(Name ="Location")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Location cannot be more than 50 characters in length.")]
		public string location;

		[Required]
		[Display(Name ="Sponsor")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Sponsor cannot be more than 50 characters in length.")]
		public string sponsor;

		[Required]
		[Display(Name ="Request Date")]
		public DateTime requestDate;

		[Required]
		[Display(Name ="Project Name")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Project Name cannot be more than 50 characters in length.")]
		public string projectName;

		[Required]
		[Display(Name ="Active")]
		public bool projectActive;

		[Display(Name ="Comment")]
		public string comment;

		[Required]
		[Display(Name = "Last Edited By")]
		public string lastEditedBy;

		[Required]
		[Display(Name = "Last Edited On")]
		public DateTime editDate;
	}

	public class ProjectRoleMetadata
	{
		[Key]
		[Required]
		[Display(Name = "Project Role ID")]
		public int projectRoleId;

		[Display(Name = "Project ID")]
		public int projectId;

		[Display(Name = "Consultant ID")]
		public Nullable<int> consultantId;

		[Required]
		[Display(Name = "Role Name")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Project Role Name cannot be more than 50 characters in length.")]
		public string projectRoleName;

		[Display(Name = "Max Target Grade")]
		[StringLength(50, ErrorMessage = "Grade cannot be more than 50 characters in length.")]
		public string maxTargetGrade;

		[Display(Name = "Target New Hire Grade")]
		[StringLength(50, ErrorMessage = "Targeted Grade cannot be more than 50 characters in length.")]
		public string targetedNewHireGrade;

		[Display(Name = "Candidate Confirmed")]
		public Nullable<bool> candidateConfirmed;

		[Display(Name = "Expected Start Date")]
		public Nullable<System.DateTime> expectedStartDate;

		[Display(Name = "Actual Start Date")]
		public Nullable<System.DateTime> actualStartDate;

		[Display(Name = "End Date")]
		public Nullable<System.DateTime> endDate;

		[Required]
		[Display(Name = "Last Edited By")]
		public string lastEditedBy;

		[Required]
		[Display(Name = "Last Edited On")]
		public System.DateTime editDate;

	}

	public class ProjectStatusMetadata
	{
		[Key]
		[Required]
		[Display(Name = "Project Status Id")]
		public int projectStatusID;

		[Required]
		[Display(Name ="Project Status")]
		[StringLength(50, ErrorMessage = "Project Status cannot be more than 50 characters in length.")]
		public string projectStatusName;
	}

	public class UserInfoMetadata
	{
	}

	public class UserPrivilegeMetadata
	{
	}
}