<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministratorForm.aspx.cs" Inherits="ooad2020E_schedule.AdministratorForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Untitled</title>
    <link rel="stylesheet" href="bootstrap.min.css" />
    <link rel="stylesheet" href="styles.css" />
    <link rel="stylesheet" href="AdminStyles.css" />
</head>
<body>
    <div>
        <ul class="nav nav-tabs">
            <li class="nav-item"><a class="nav-link active" role="tab" data-toggle="tab" href="#tab-1">Tab 1</a></li>
            <li class="nav-item"><a class="nav-link" role="tab" data-toggle="tab" href="#tab-2">Tab 2</a></li>
            <li class="nav-item"><a class="nav-link" role="tab" data-toggle="tab" href="#tab-3">Tab 3</a></li>
        </ul>
        <div class="tab-content">
            <div class="tab-pane active" role="tabpanel" id="tab-1">
                <p>Content for tab 1.</p>
            </div>
            <div class="tab-pane" role="tabpanel" id="tab-2">
                <p>Content for tab 2.</p>
            </div>
            <div class="tab-pane" role="tabpanel" id="tab-3">
                <p>Content for tab 3.</p>
            </div>
        </div>
    </div>
</body>
</html>
