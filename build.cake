///////////////////////////////////////////////////////////////////////////////
// IMPORTS
///////////////////////////////////////////////////////////////////////////////

#load "./build/scripts/imports.cake"





//////////////////////////////////////////////////////////////////////
// SOLUTION
//////////////////////////////////////////////////////////////////////

// Name
var appName = "Cake.Topshelf";

// Projects
var projectNames = new List<string>() 
{ 
    "Cake.Topshelf"
};





///////////////////////////////////////////////////////////////////////////////
// LOAD
///////////////////////////////////////////////////////////////////////////////

#load "./build/scripts/load.cake"