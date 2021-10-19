# Tools
    - It is recommended to use an application that allows you to easily navigate the DB.  There are multiple tools that allow you to do this.  A couple that i know of are HeidiSQL, which is included in a typical MariaDB package for WIndows.  I use a program called DBeaver [https://dbeaver.io/](https://dbeaver.io/) and it works well for these types of verifications/needs

# Automated
    - The app should apply a migration to the Signum Node database.  This will automatically add the necessary INDEX(s) and VIEW(s).
    - There will also be an additional TABLE that is created as a result of the EntityFramework Core Migration process... ( __efmigrationshistory ). If there are suspected issues with the automated creation of these views/indexes it is possible to DROP this table, restart the app and the Migration will try to apply itself again. 

## Database Scripts for Manual setup
    - The Views and Indexes Folders contain .sql scripts for MariaDB .  These can be run on the Signum Node DB to manually create the necessary views and indexes to allow the site to work properly.

