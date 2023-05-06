export interface Move {
    id: number;

    name: string;

    type: string;

    powerPoints: number;

    basePower: number;

    accuracy: number;

    battleEffect: number;

    effectRate: number;

    priority: number;

    target: string;
}