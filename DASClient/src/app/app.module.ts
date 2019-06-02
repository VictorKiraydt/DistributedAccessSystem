import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ChartsModule } from 'ng2-charts';

import { HeaderComponent } from './shared/header/header.component';
import { NavComponent } from './shared/nav/nav.component';
import { FooterComponent } from './shared/footer/footer.component';

import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { CustomersComponent } from './pages/customers/customers.component';

import { ProjectsPoolComponent } from './pages/utilities/projects-pool/projects-pool.component';
import { UsersPoolComponent } from './pages/utilities/users-pool/users-pool.component';
import { ProjectsAttrComponent } from './pages/utilities/projects-attr/projects-attr.component';
import { SearchServiceRComponent } from './pages/utilities/search-service-r/search-service-r.component';
import { AlertsCancellationComponent } from './pages/utilities/alerts-cancellation/alerts-cancellation.component';
import { ProjectConfigComponent } from './pages/utilities/project-config/project-config.component';
import { ProjectGrpDelComponent } from './pages/utilities/project-grp-del/project-grp-del.component';
import { ProjectInfoComponent } from './pages/utilities/project-info/project-info.component';

import { ProjectUsersMnComponent } from './pages/project-users-mn/project-users-mn.component';
import { DuoUsersMnComponent } from './pages/duo-users-mn/duo-users-mn.component';
import { ServicesBacklogComponent } from './pages/services-backlog/services-backlog.component';
import { ProcessMonitoringComponent } from './pages/process-monitoring/process-monitoring.component';
import { ReportGenerationComponent } from './pages/report-generation/report-generation.component';
import { ExpViewerComponent } from './pages/exp-viewer/exp-viewer.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    NavComponent,
    FooterComponent,
    LoginComponent,
    HomeComponent,
    CustomersComponent,
    ProjectsPoolComponent,
    UsersPoolComponent,
    SearchServiceRComponent,
    AlertsCancellationComponent,
    ProjectConfigComponent,
    ProjectGrpDelComponent,
    ProjectInfoComponent,
    ProjectsAttrComponent,
    ProjectUsersMnComponent,
    DuoUsersMnComponent,
    ServicesBacklogComponent,
    ProcessMonitoringComponent,
    ReportGenerationComponent,
    ExpViewerComponent,
],
imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    ChartsModule
],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(router: Router) { }
}
