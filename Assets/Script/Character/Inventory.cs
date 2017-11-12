

namespace CarAdventure.Entity {
    public class Inventory {

        int gold;
        
        public Inventory() {
            gold = 0;
        }
        internal void UpdateGold(int number) {
            gold += number;
        }
    }
}