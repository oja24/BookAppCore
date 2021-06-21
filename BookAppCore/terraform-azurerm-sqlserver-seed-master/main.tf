
 provider "azurerm" {
 version = "=2.0.0"
 features {}
  subscription_id = "55f02284-ce87-4fd9-98e2-f41f32cf21a9"
#   client_id       = "REPLACE-WITH-YOUR-CLIENT-ID"
#   client_secret   = "REPLACE-WITH-YOUR-CLIENT-SECRET"

  tenant_id       = "b384c323-fd39-4008-b967-3fc84b0bc4ca"

 }

locals {
  db_server = "${split(".", var.db_server_fqdn)}"
}


resource "azurerm_sql_database" "db" {
  name                             = "${var.db_name}"
  location                         = "${var.location}"
  resource_group_name              = "${var.resource_group}"
  server_name                      = "${local.db_server[0]}"
  edition                          = "${var.db_edition}"
  collation                        = "${var.collation}"
  requested_service_objective_name = "${var.service_objective_name}"
  create_mode                      = "Default"

  provisioner "local-exec" {
    command = "sqlcmd -U ${var.sql_admin_username} -P ${var.sql_admin_password} -S ${var.db_server_fqdn} -d ${var.db_name} -i ${var.init_script_file} -o ${var.log_file}"
  }
}
