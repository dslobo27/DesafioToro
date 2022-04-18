import { NgModule } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from 'src/app/pages/home/home.component';
import { LoginComponent } from "src/app/pages/login/login.component";

const routes: Routes = [
    {
      path: '',
      component: LoginComponent
    },
    {
      path: 'home',
      component: HomeComponent
    }
  ];

  @NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule {}