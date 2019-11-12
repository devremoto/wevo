import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthCanActivateGuard } from './auth/auth-can-activate.guard';
import { AdminLayoutModule } from './admin/_layout/admin-layout.module';
const routes: Routes = [
  { path: '', data: { title: 'Home' }, redirectTo: 'admin', pathMatch: 'full' },
  {
    path: '',
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
    canActivate: [AuthCanActivateGuard]
  }
];

@NgModule({
  imports: [
    AdminLayoutModule,
    RouterModule.forRoot(routes, {
      scrollPositionRestoration: 'enabled',
      useHash: false,
      anchorScrolling: 'enabled'
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
