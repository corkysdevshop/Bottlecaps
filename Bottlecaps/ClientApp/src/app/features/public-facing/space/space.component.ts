import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { BottlecapService } from '../../private/my-bottlecaps/bottlecap.service';
import { SpaceAreaComponent } from './space-area/space-area.component';
import { Bottlecap } from '../../../shared/models';
import { SpaceService } from './space.service';

@Component({
  selector: 'app-space',
  templateUrl: './space.component.html',
  styleUrls: ['./space.component.css']
})
export class SpaceComponent implements OnInit{
	@ViewChild(SpaceAreaComponent, { static: false }) spaceArea: SpaceAreaComponent;
	spaceCollection: Bottlecap[] = [];

	constructor(private bottlecapService: BottlecapService,
              private spaceService: SpaceService	) { }

	ngOnInit() {
		this.bottlecapService.getBottlecaps(1); //TODO: THIS SHOULD PASS AN ARRAY OF BOTTLCAP IDS AND RETURN AN ARRAY SLICE TO HOLD IN THIS COMPONENT, HOWEVER FOR NOW I'LL JUST REFERENCE THE BOTTLECAP SERVICE TO GET THE IDS TO PLACE IN THE SPACE
	}
	placeBottlecap(bottlecapId) {
		//console.log("index: ", bottlecapId.selectedIndex);
		console.log("value: ", bottlecapId);
    // STORE BOTTLECAP IN SPACE
		this.spaceService.addBottlecapToSpace(bottlecapId);
    // OLD WAY TO PLACE BOTTLECAP DIRECTLY ON SPACE IN MEMORY
		//this.spaceArea.placeBottlecap(bottlecap.value);
	}
}
