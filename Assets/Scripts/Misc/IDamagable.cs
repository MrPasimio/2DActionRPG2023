public interface IDamagable
{
    //Lesson 10 Damage Interface
    //An interface is a list of functions that I can define
    // and attach to another class

    void TakeDamage(int damageToTake);
    void Die();
    Character.Team GetTeam();
}