import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
<<<<<<< HEAD
import { CarPartListComponent } from './components/cart-part/car-part-list/car-part-list.component';
import { CarPartAddComponent } from './components/cart-part/car-part-add/car-part-add.component';
=======
>>>>>>> 4ed68c7c2cf7e72f01f92db1c3ca10c0d82e032a

const routes: Routes = [
  {path:'', component:HomeComponent},
  {path:'home', component:HomeComponent},
<<<<<<< HEAD
  { path:'car-parts', component:CarPartListComponent},
  { path:'car-part-add', component:CarPartAddComponent}
=======
>>>>>>> 4ed68c7c2cf7e72f01f92db1c3ca10c0d82e032a

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
