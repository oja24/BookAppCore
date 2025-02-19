provider "azurerm" {
version = ">0.13"
features {}
}




terraform {
  backend "azure" { 
    resource_group_name  = "TerraformStorageRG"
    storage_account_name = "lightbeamterraformsa"
    container_name       = "terraform"
    key = "terraform.tfstate"
  }
}


resource "azurerm_sql_server" "presentation" {
  name                         = var.SqlServerName
  resource_group_name          = var.ResourceGroupName
  location                     = var.location
  version                      = "12.0"
  administrator_login          = "SQLServerAdminUser"
  administrator_login_password = "Ba#ro%6Yt_0"
    tags = {
    environment = "$var.presentation"
  }
}

resource "azurerm_sql_database" "presentation" {
  name                = var.SqlDatabaseName
  resource_group_name = var.ResourceGroupName
  location            = var.location
  server_name         = var.SqlServerName
  edition                          = "Business"
  

  tags = {
    environment = "$var.presentation"
  }
  

  
}
