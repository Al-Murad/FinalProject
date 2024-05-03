import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
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

@NgModule({
  declarations: [
    AppComponent,
<<<<<<< HEAD
    NavBarComponent,
    HomeComponent
=======
    NavBarComponent
>>>>>>> ca6fd2ee2aacf76dc70882cd642e59388bf132c6
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
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
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
