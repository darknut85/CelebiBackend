import { LevelupMove } from "./levelupMove";

export interface Pokemon{
    id: number;

    name: string;

    dexEntry: number;

    classification: string;

    type1: string;

    type2: string;

    height: number;

    weight: number;

    pokedexEntry: string;

    growthRate: number;

    captureRate: number;

    hp: number;

    atk: number;

    def: number;

    spatk: number;

    spdef: number;

    spd: number;

    hpev: number;

    atkev: number;

    defev: number;

    spatkev: number;

    spdefev: number;

    spdev: number;

    levelUpMoves: LevelupMove[];
}
