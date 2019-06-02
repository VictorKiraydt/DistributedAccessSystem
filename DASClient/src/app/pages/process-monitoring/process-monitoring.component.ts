import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-process-monitoring',
  templateUrl: './process-monitoring.component.html',
  styleUrls: ['./process-monitoring.component.css']
})
export class ProcessMonitoringComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  public tableData = [
    { data: [5289, "BulkSave peration", 80123, "Save", 56, "victorkiraydt@yaho0.com", 40] },
    { data: [5291, "Document Viewing", 40432, "Viewer", 86, "user@user.com", 90] },
    { data: [5293, "Copy to project", 40123, "Copy", 27, "testuser.vk0@gmail.com", 30] },
    { data: [5295, "Document downloding", 10321, "Download", 96, "test@test.test", 20] },
    { data: [5297, "Report generation", 20678, "Report", 57, "test@test.test", 20] },
    { data: [5299, "BulkPrint operation", 60876, "Print", 36, "user@user.com", 90] },
    { data: [5361, "Users addition", 80345, "AddUser", 28, "testuser.vk0@gmail.com", 30] },
    { data: [5363, "Users deletion", 80654, "DeleteUser", 29, "victorkiraydt@yah0o.com", 40] },
    { data: [5365, "BulkSave peration", 70344, "Save", 56, "victorkiraydt@yah0o.com", 40] },
    { data: [5367, "Document Viewing", 40442, "Viewer", 86, "victorkiraydt@yah0o.com", 40] },
    { data: [5369, "Copy to project", 40098, "Copy", 27, "user@user.com", 90] },
    { data: [5413, "Document downloding", 40009, "Download", 96, "test@test.test", 20] },
    { data: [5415, "Report generation", 30966, "Report", 57, "test@test.test", 20] },
    { data: [5417, "BulkPrint operation", 30742, "Print", 36, "user@user.com", 90] },
    { data: [5419, "Users deletion", 77000, "DeleteUser", 29, "test@test.test", 20] }
  ];
  public tableLabels = [
    'ID', 'EventType', 'TypeID', 'ProcessName', 'ProcessID', 'Email', 'UserID'
  ];

}
