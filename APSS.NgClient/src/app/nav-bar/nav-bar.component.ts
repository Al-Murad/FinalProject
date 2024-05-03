import { Component, inject } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { navItems } from '../shared/app-constants';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {
  private breakpointObserver = inject(BreakpointObserver);
  items = navItems;
  config = {
    paddingAtStart: true,
    interfaceWithRoute: true,
    useDividers: true,
    rtlLayout: false,
    listBackgroundColor: `#77B0AA`,
    fontColor: `rgb(8, 54, 71)`,
    backgroundColor: `#77B0AA`,
    selectedListFontColor: `#E3FEF7`,
    
};
 selectedItem(event:any){
  console.log(event);
 }
}
