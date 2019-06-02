import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './core/auth.guard';
import { JwtHelper } from 'angular2-jwt';

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

const routes: Routes = [
    { path: 'login', component: LoginComponent },
    {
        path: '',
        children: [
            {
                path: 'home',
                redirectTo: '',
                pathMatch: 'full'
            }
        ],
        component: HomeComponent,
        canActivate: [AuthGuard]
    },
    { path: 'customers', component: CustomersComponent, canActivate: [AuthGuard] },

    {
        path: 'utilities/projects-pool',
        children: [
            {
                path: 'utilities',
                redirectTo: 'utilities/projects-pool',
                pathMatch: 'full'
            }
        ],
        component: ProjectsPoolComponent,
        canActivate: [AuthGuard]
    },
    { path: 'utilities/users-pool', component: UsersPoolComponent, canActivate: [AuthGuard] },
    { path: 'utilities/projects-attr', component: ProjectsAttrComponent, canActivate: [AuthGuard] },
    { path: 'utilities/search-service-r', component: SearchServiceRComponent, canActivate: [AuthGuard] },
    { path: 'utilities/alerts-cancellation', component: AlertsCancellationComponent, canActivate: [AuthGuard] },
    { path: 'utilities/project-config', component: ProjectConfigComponent, canActivate: [AuthGuard] },
    { path: 'utilities/project-grp-del', component: ProjectGrpDelComponent, canActivate: [AuthGuard] },
    { path: 'utilities/project-info', component: ProjectInfoComponent, canActivate: [AuthGuard] },

    { path: 'project-users-mn', component: ProjectUsersMnComponent, canActivate: [AuthGuard] },
    { path: 'duo-users-mn', component: DuoUsersMnComponent, canActivate: [AuthGuard] },
    { path: 'services-backlog', component: ServicesBacklogComponent, canActivate: [AuthGuard] },
    { path: 'process-monitoring', component: ProcessMonitoringComponent, canActivate: [AuthGuard] },
    { path: 'report-generation', component: ReportGenerationComponent, canActivate: [AuthGuard] },
    { path: 'exp-viewer', component: ExpViewerComponent, canActivate: [AuthGuard] }
];

@NgModule ({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [RouterModule],
    providers: [JwtHelper, AuthGuard]
})
export class AppRoutingModule { }