variable "presentation" {
    description = "The name of the presentation - used for tagging Azure resources so I know what they belong to"
    default = "__Presentation__"
}

variable "ResourceGroupName" {
  description = "The Prefix used for all resources in this example"
  default     = "__ResourceGroupName__"
}

variable "location" {
  description = "The Azure Region in which the resources in this example should exist"
  default     = "__location__"
}

variable "SqlServerName" {
  description = "The name of the Azure SQL Server to be created or to have the database on - needs to be unique, lowercase between 3 and 24 characters including the prefix"
  default     = "__SqlServerName__"
}

variable "SQLServerAdminUser" {
  description = "The name of the Azure SQL Server Admin user for the Azure SQL Database"
  default     = "__SQLServerAdminUser__"
}
variable "SQLServerAdminPassword" {
  description = "The Azure SQL Database users password"
  default     = "__SQLServerAdminPassword__"
}
variable "SqlDatabaseName" {
  description = "The name of the Azure SQL database on - needs to be unique, lowercase between 3 and 24 characters including the prefix"
  default     = "__SqlDatabaseName__"
}


variable "Edition" {
  description = "The Edition of the Database - Basic, Standard, Premium, or DataWarehouse"
  default     = "__Edition__"
}

variable "ServiceObjective" {
  description = "The Service Tier S0, S1, S2, S3, P1, P2, P4, P6, P11 and ElasticPool"
  default     = "__ServiceObjective__"
}