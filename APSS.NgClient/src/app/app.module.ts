import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
<<<<<<< HEAD

import { MultilevelMenuService,NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { MatImportModule } from './modules/mat-import/mat-import.module';
import { HomeComponent } from './components/home/home.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { CarPartListComponent } from './components/cart-part/car-part-list/car-part-list.component';
import { CarPartAddComponent } from './components/cart-part/car-part-add/car-part-add.component';
import { ProductService } from './services/product.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ServiceTypeService } from './services/service-type.service';
import { ReactiveFormsModule } from '@angular/forms';

=======
<<<<<<< HEAD
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MultilevelMenuService,NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { MatImportModule } from './modules/mat-import/mat-import.module';
import { HomeComponent } from './components/home/home.component';

=======
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
>>>>>>> ca6fd2ee2aacf76dc70882cd642e59388bf132c6
>>>>>>> 4ed68c7c2cf7e72f01f92db1c3ca10c0d82e032a

@NgModule({
  declarations: [
    AppComponent,
<<<<<<< HEAD
    NavBarComponent,
    HomeComponent,
    CarPartListComponent,
    CarPartAddComponent
=======
<<<<<<< HEAD
    NavBarComponent,
    HomeComponent
=======
    NavBarComponent
>>>>>>> ca6fd2ee2aacf76dc70882cd642e59388bf132c6
>>>>>>> 4ed68c7c2cf7e72f01f92db1c3ca10c0d82e032a
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
<<<<<<< HEAD
    HttpClientModule,
    MatImportModule,
    NgMaterialMultilevelMenuModule,
    ReactiveFormsModule
  ],
  providers: [
    provideAnimationsAsync(),
    MultilevelMenuService,
    HttpClient,
    ProductService,
    ServiceTypeService

=======
<<<<<<< HEAD
    MatImportModule,
    NgMaterialMultilevelMenuModule
  ],
  providers: [
    provideAnimationsAsync(),
    MultilevelMenuService

=======
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule
  ],
  providers: [
    provideAnimationsAsync()
>>>>>>> ca6fd2ee2aacf76dc70882cd642e59388bf132c6
>>>>>>> 4ed68c7c2cf7e72f01f92db1c3ca10c0d82e032a
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
