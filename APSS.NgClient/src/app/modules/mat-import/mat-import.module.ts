import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 4ed68c7c2cf7e72f01f92db1c3ca10c0d82e032a
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import {MatTableModule} from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatDialogModule} from '@angular/material/dialog';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatSelectModule} from '@angular/material/select';
import {MatRadioModule} from '@angular/material/radio';
<<<<<<< HEAD
import {MatTabsModule} from '@angular/material/tabs';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatProgressBarModule} from '@angular/material/progress-bar';

=======
>>>>>>> 4ed68c7c2cf7e72f01f92db1c3ca10c0d82e032a
const modules= [
  MatToolbarModule,
  MatButtonModule,
  MatSidenavModule,
  MatIconModule,
  MatListModule,
  MatTableModule,
  MatSortModule,
  MatPaginatorModule,
  MatCardModule,
  MatFormFieldModule,
  MatInputModule,
  MatSnackBarModule,
  MatDialogModule,
  MatDatepickerModule,
  MatSelectModule,
<<<<<<< HEAD
  MatRadioModule,
  MatTabsModule,
  MatAutocompleteModule,
  MatProgressBarModule
];


=======
  MatRadioModule
];


=======
>>>>>>> ca6fd2ee2aacf76dc70882cd642e59388bf132c6
>>>>>>> 4ed68c7c2cf7e72f01f92db1c3ca10c0d82e032a


@NgModule({
  declarations: [],
  imports: [
<<<<<<< HEAD
    CommonModule, ...modules
  ],
  exports:[...modules]
=======
<<<<<<< HEAD
    CommonModule, ...modules
  ],
  exports:[...modules]
=======
    CommonModule
  ]
>>>>>>> ca6fd2ee2aacf76dc70882cd642e59388bf132c6
>>>>>>> 4ed68c7c2cf7e72f01f92db1c3ca10c0d82e032a
})
export class MatImportModule { }
