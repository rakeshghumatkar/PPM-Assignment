package com.example.PPM.Repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.example.PPM.Model.Role;

@Repository
public interface RoleRepo extends JpaRepository<Role, Integer>
{

}
