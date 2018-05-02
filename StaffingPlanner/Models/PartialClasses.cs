using System;
using System.ComponentModel.DataAnnotations;

namespace StaffingPlanner.Models
{
	[MetadataType(typeof(ClientMetadata))]
	public partial class Client
	{
	}

	[MetadataType(typeof(ConsultantMetadata))]
	public partial class Consultant
	{
	}

	[MetadataType(typeof(LostOpportunityMetadata))]
	public partial class LostOpportunity
	{
	}

	[MetadataType(typeof(LostReasonMetadata))]
	public partial class LostReason
	{
	}

	[MetadataType(typeof(ProjectMetadata))]
	public partial class Project
	{
	}

	[MetadataType(typeof(ProjectRoleMetadata))]
	public partial class ProjectRole
	{
	}

	[MetadataType(typeof(ProjectStatusMetadata))]
	public partial class ProjectStatus
	{
	}

	[MetadataType(typeof(UserInfoMetadata))]
	public partial class UserInfo
	{
	}

	[MetadataType(typeof(UserPrivilegeMetadata))]
	public partial class UserPrivilege
	{
	}
}