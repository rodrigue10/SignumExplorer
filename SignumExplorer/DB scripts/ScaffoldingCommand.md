﻿Use this PackageManager command to scaffold the Signum Node DB 
and create the model and context for any new changes to the node.

Helpful when trying to create and add views directly on the DB, then using this to create the model for you.

Context folder is set to a temp directory.  I don't want to overwrite the current one due to the dependencies setup there.
Model folder can be overwritten.  
This creates `partial` classes.... (DO NOT MAKE MODIFICATIONS to these classes as they are autogenerated)
These partial classes have been extended and used in another part of the project along with the definitions of their associated interfaces.

Scaffold-DbContext "server=srs-node;user=signum;password=signumpassword;database=signum" -Provider Pomelo.EntityFrameworkCore.MySql -ContextDir ContextTemp -OutputDir Models -Force
